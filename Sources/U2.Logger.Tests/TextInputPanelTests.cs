using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ReportChangedTextBoxValue(ApplicationTextBox textBox)
        {
            var model = new TextInputPanelViewModel();
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
            }

            Assert.AreEqual(expectedValue, _newValue);
            Assert.IsTrue(_textBox.HasValue);
            Assert.AreEqual(textBox, _textBox.Value);
        }
    }
}
