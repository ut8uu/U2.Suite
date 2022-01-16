using System;
using System.Collections.Generic;
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
        private LoggerMainWindowViewModel _loggerVM;

        const string CallsignField = "Callsign";
        const string RstSentField = "Rst Sent";
        const string RstReceivedField = "Rst Received";
        const string OperatorField = "Operator";
        const string CommentsField = "Comments";

        const string WipeButton = "Wipe";
        const string SaveButton = "Save";

        public BddLogging(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitTest()
        {
            _textInputVM = new TextInputPanelViewModel();
            _loggerVM = new LoggerMainWindowViewModel();
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

            throw new ArgumentException($"Unknown field name '{fieldName}'");
        }

        [Given(@"Field '(.*)' contains '(.*)'")]
        public void GivenFieldContains(string fieldName, string fieldValue)
        {
            SetFieldValue(fieldName, fieldValue);            
        }

        [When(@"User clicks the '(.*)' button")]
        public void WhenUserClicksTheButton(string buttonName)
        {
            var button = ButtonFromString(buttonName);
            Messenger.Default.Send(new ButtonClickedMessage(this, button));
        }

        [Then(@"Field '(.*)' contains '(.*)'")]
        public void ThenFieldContains(string fieldName, string expectedFieldValue)
        {
            var value = GetFieldValue(fieldName);
            Assert.AreEqual(expectedFieldValue, value);
        }

        [Given(@"All fields are not empty")]
        public void GivenAllFieldsAreNotEmpty()
        {
            SetFieldValue(CallsignField, "UT8UU");
            SetFieldValue(RstReceivedField, "589");
            SetFieldValue(RstSentField, "599");
            SetFieldValue(OperatorField, "Sergey");
            SetFieldValue(CommentsField, "good signal");
        }

        [Then(@"Field '(.*)' is not empty")]
        public void ThenFieldIsNotEmpty(string fieldName)
        {
            var fieldValue = GetFieldValue(fieldName);
            Assert.IsFalse(string.IsNullOrEmpty(fieldValue), $"Field {fieldName} is empty.");
        }

    }
}
