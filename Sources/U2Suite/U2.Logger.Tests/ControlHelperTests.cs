using System;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class ControlHelperTests
    {
        
        [TestMethod]
        [DataRow(TextInputPanelViewModel.CallsignTextBox, ApplicationTextBox.Callsign)]
        [DataRow(TextInputPanelViewModel.RstRcvdTextBox, ApplicationTextBox.RstReceived)]
        [DataRow(TextInputPanelViewModel.RstSentTextBox, ApplicationTextBox.RstSent)]
        [DataRow(TextInputPanelViewModel.OperatorTextBox, ApplicationTextBox.Operator)]
        [DataRow(TextInputPanelViewModel.CommentsTextBox, ApplicationTextBox.Comments)]
        public void ReportClickedButton(string textBoxName, ApplicationTextBox expectedTextBox)
        {
            var textBox = ControlHelper.TextBoxFromString(textBoxName);
            Assert.AreEqual(expectedTextBox, textBox);
        }
    }
}
