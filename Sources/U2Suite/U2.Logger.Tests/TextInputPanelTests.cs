using System;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;
using U2.Core;
using U2.Logger;

namespace U2.Logger.Tests
{
    [TestClass]
    public class TextInputPanelTests
    {
        private string _newValue;
        private ApplicationTextBox? _textBox;

        private void AcceptTextChangedMessage(TextChangedMessage message)
        {
            _newValue = message.NewValue;
            _textBox = message.TextBox;
        }

        [TestInitialize]
        public void InitTest()
        {
            _newValue = default!;
            _textBox = null;

            Messenger.Default.Register<TextChangedMessage>(this,
                AcceptTextChangedMessage);
        }

        [TestMethod]
        [DataRow(ApplicationTextBox.Callsign)]
        [DataRow(ApplicationTextBox.RstReceived)]
        [DataRow(ApplicationTextBox.RstSent)]
        [DataRow(ApplicationTextBox.Operator)]
        [DataRow(ApplicationTextBox.Comments)]
        [DataRow(ApplicationTextBox.Mode)]
        [DataRow(ApplicationTextBox.Band)]
        //[DataRow(ApplicationTextBox.Timestamp)]
        [DataRow(ApplicationTextBox.Frequency)]
        public void ReportChangedTextBoxValue(ApplicationTextBox textBox)
        {
            var model = new TextInputPanelViewModel
            {
                Realtime = false
            };
            var expectedValue = "test value";
            switch (textBox)
            {
                case ApplicationTextBox.Callsign:
                    model.Callsign = expectedValue;
                    break;
                case ApplicationTextBox.Operator:
                    model.Operator = expectedValue;
                    break;
                case ApplicationTextBox.RstReceived:
                    model.RstRcvd = expectedValue;
                    break;
                case ApplicationTextBox.RstSent:
                    model.RstSent = expectedValue;
                    break;
                case ApplicationTextBox.Comments:
                    model.Comments = expectedValue;
                    break;
                case ApplicationTextBox.Timestamp:
                    expectedValue = DateTime.UtcNow.ToString("g");
                    model.Timestamp = expectedValue;
                    break;
                case ApplicationTextBox.Mode:
                    expectedValue = ConversionHelper.AllModes.First().Name;
                    model.Mode = expectedValue;
                    break;
                case ApplicationTextBox.Band:
                    expectedValue = RadioBandName.B160m;
                    model.Band = expectedValue;
                    break;
                case ApplicationTextBox.Frequency:
                    model.Frequency = expectedValue;
                    break;
            }

            Assert.AreEqual(expectedValue, _newValue);
            Assert.IsTrue(_textBox.HasValue);
            Assert.AreEqual(textBox, _textBox.Value);
        }

        /// <summary>
        /// This is to check how which properties are loaded
        /// in the form view by default.
        /// </summary>
        [TestMethod]
        public void LoadDefaultValues()
        {
            var viewModel = new TextInputPanelViewModel();
            var expectedMode = ConversionHelper.AllModes.First().Name;
            var expectedBand = ConversionHelper.AllBands.First().Name;
            var expectedFrequency = ConversionHelper.BandNameAndModeToFrequency(expectedBand, expectedMode).ToString();
            var expectedReport = ConversionHelper.ModeToDefaultReport(expectedMode);
            Assert.AreEqual(expectedMode, viewModel.Mode);
            Assert.AreEqual(expectedBand, viewModel.Band);
            Assert.AreEqual(expectedFrequency, viewModel.Frequency);
            Assert.AreEqual(expectedReport, viewModel.RstRcvd);
            Assert.AreEqual(expectedReport, viewModel.RstSent);
        }
    }
}
