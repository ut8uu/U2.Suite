using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace U2.Logger.Tests
{
    [Binding]
    public sealed class BddLogging
    {
        private readonly ScenarioContext _scenarioContext;
        private TextInputPanelViewModel _textInputVM;
        private MainWindowViewModel _loggerVM;

        readonly static string CallsignField = Resources.Callsign;
        readonly static string RstSentField = Resources.RstSent;
        readonly static string RstReceivedField = Resources.RstReceived;
        readonly static string OperatorField = Resources.Operator;
        readonly static string CommentsField = Resources.Comments;
        readonly static string BandField = Resources.Band;

        readonly static string WipeButton = Resources.WipeButtonTitle;
        readonly static string SaveButton = Resources.SaveButtonTitle;

        readonly List<Exception> _caughtExceptions = new List<Exception>();

        public BddLogging(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitTest()
        {
            _textInputVM = new TextInputPanelViewModel();
            _loggerVM = new MainWindowViewModel();
            _caughtExceptions.Clear();
        }

        private static ApplicationTextBox TextBoxFromString(string fieldName)
        {
            if (fieldName.Equals(CallsignField, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationTextBox.Callsign;
            }
            if (fieldName.Equals(RstSentField, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationTextBox.RstSent;
            }
            if (fieldName.Equals(RstReceivedField, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationTextBox.RstReceived;
            }
            if (fieldName.Equals(OperatorField, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationTextBox.Operator;
            }
            if (fieldName.Equals(CommentsField, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationTextBox.Comments;
            }

            throw new ArgumentException($"Unknown field name '{fieldName}'");
        }

        private static ApplicationButton ButtonFromString(string buttonName)
        {
            if (buttonName.Equals(WipeButton, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationButton.WipeButton;
            }
            if (buttonName.Equals(SaveButton, StringComparison.InvariantCultureIgnoreCase))
            {
                return ApplicationButton.SaveButton;
            }

            throw new ArgumentException($"Button '{buttonName}' not found");
        }

        private void SetFieldValue(string fieldName, string fieldValue)
        {
            if (fieldName.Equals(CallsignField, StringComparison.InvariantCultureIgnoreCase))
            {
                _textInputVM.Callsign = fieldValue;
            }
            else if (fieldName.Equals(RstSentField, StringComparison.InvariantCultureIgnoreCase))
            {
                _textInputVM.RstSent = fieldValue;
            }
            else if (fieldName.Equals(RstReceivedField, StringComparison.InvariantCultureIgnoreCase))
            {
                _textInputVM.RstRcvd = fieldValue;
            }
            else if (fieldName.Equals(OperatorField, StringComparison.InvariantCultureIgnoreCase))
            {
                _textInputVM.Operator = fieldValue;
            }
            else if (fieldName.Equals(CommentsField, StringComparison.InvariantCultureIgnoreCase))
            {
                _textInputVM.Comments = fieldValue;
            }
            else
            {
                throw new ArgumentException($"Unknown field name '{fieldName}'");
            }
        }

        private string GetFieldValue(string fieldName)
        {
            if (fieldName.Equals(CallsignField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.Callsign;
            }
            if (fieldName.Equals(RstSentField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.RstSent;
            }
            if (fieldName.Equals(RstReceivedField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.RstRcvd;
            }
            if (fieldName.Equals(OperatorField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.Operator;
            }
            if (fieldName.Equals(CommentsField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.Comments;
            }
            if (fieldName.Equals(BandField, StringComparison.InvariantCultureIgnoreCase))
            {
                return _textInputVM.Band;
            }

            throw new ArgumentException($"Unknown field name '{fieldName}'");
        }

        [Given("Field '(.*)' contains '(.*)'")]
        public void GivenFieldContains(string fieldName, string fieldValue)
        {
            SetFieldValue(fieldName, fieldValue);            
        }

        [When("User clicks the '(.*)' button")]
        public void WhenUserClicksTheButton(string buttonName)
        {
            var button = ButtonFromString(buttonName);
            Messenger.Default.Send(new ButtonClickedMessage(this, button));
        }

        [Then("Field '(.*)' contains '(.*)'")]
        public void ThenFieldContains(string fieldName, string expectedFieldValue)
        {
            var value = GetFieldValue(fieldName);
            Assert.AreEqual(expectedFieldValue, value);
        }

        [Given("All fields are not empty")]
        public void GivenAllFieldsAreNotEmpty()
        {
            SetFieldValue(CallsignField, "UT8UU");
            SetFieldValue(RstReceivedField, "589");
            SetFieldValue(RstSentField, "599");
            SetFieldValue(OperatorField, "Sergey");
            SetFieldValue(CommentsField, "good signal");
        }

        [Given("Mode is '(.*)'")]
        public void GivenModeIs(string mode)
        {
            _textInputVM.Mode = mode;
        }

        [Given("Frequency is (.*)")]
        public void GivenFrequencyIs(double frequency)
        {
            try
            {
                _textInputVM.Frequency = frequency.ToString(CultureInfo.DefaultThreadCurrentUICulture);
            }
            catch (Avalonia.Data.DataValidationException ex)
            {
                _caughtExceptions.Add(ex);
            }
        }


        [Then("Field '(.*)' is not empty")]
        public void ThenFieldIsNotEmpty(string fieldName)
        {
            var fieldValue = GetFieldValue(fieldName);
            Assert.IsFalse(string.IsNullOrEmpty(fieldValue), $"Field {fieldName} is empty.");
        }

        [Given("Log is empty")]
        public void GivenLogIsEmpty()
        {
            var db = LoggerDbContext.Instance;
            foreach (var record in db.Records)
            {
                db.Records.Remove(record);
            }
            db.SaveChanges();

            Assert.AreEqual(0, db.Records.Count());
        }

        [Given(@"Realtime is turned '([^']*)'")]
        public void GivenRealtimeIsTurned(string onOffValue)
        {
            switch (onOffValue)
            {
                case "on":
                    _textInputVM.Realtime = true;
                    break;
                case "off":
                    _textInputVM.Realtime = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"A value expected to be 'on' or 'off'. Actual value is '{onOffValue}'");
            }
        }


        [Then("All fields are empty")]
        public void ThenAllFieldsAreEmpty()
        {
            Assert.IsTrue(string.IsNullOrEmpty(GetFieldValue(CallsignField)));
            Assert.IsTrue(string.IsNullOrEmpty(GetFieldValue(OperatorField)));
            Assert.IsTrue(string.IsNullOrEmpty(GetFieldValue(CommentsField)));
        }

        [Then("Log contains (.*) records")]
        public void ThenLogContainsRecord(int expectedNumberOfRecords)
        {
            Assert.AreEqual(expectedNumberOfRecords, LoggerDbContext.Instance.Records.Count());
        }

        [Then("Exception with text '(.*)' was thrown")]
        public void ThenExceptionWithTextWasThrown(string msg)
        {
            Assert.IsTrue(_caughtExceptions.Any(ex => ex.Message.Contains(msg, StringComparison.InvariantCultureIgnoreCase)));
            _caughtExceptions.Clear();
        }

        [Then("Band is '(.*)'")]
        public void ThenBandIs(string bandName)
        {
            Assert.AreEqual(bandName, GetFieldValue(BandField));
        }
    }
}
