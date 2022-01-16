using System;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        private LoggerMainWindowViewModel GetFilledLoggerViewModel()
        {
            var model = new LoggerMainWindowViewModel();
            var fd = model._currentFormData;
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Callsign, nameof(fd.Callsign)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Operator, nameof(fd.Operator)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.RstReceived, nameof(fd.RstRcvd)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.RstSent, nameof(fd.RstSent)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Comments, nameof(fd.Comments)));

            fd = model._currentFormData;
            Assert.IsFalse(string.IsNullOrEmpty(fd.Callsign));
            Assert.IsFalse(string.IsNullOrEmpty(fd.RstRcvd));
            Assert.IsFalse(string.IsNullOrEmpty(fd.RstSent));
            Assert.IsFalse(string.IsNullOrEmpty(fd.Operator));
            Assert.IsFalse(string.IsNullOrEmpty(fd.Comments));

            return model;
        }


        [TestMethod]
        public void ReportChangedText()
        {
            var model = GetFilledLoggerViewModel();

            var fd = model._currentFormData;
            Assert.AreEqual(nameof(fd.Callsign), fd.Callsign);
            Assert.AreEqual(nameof(fd.Operator), fd.Operator);
            Assert.AreEqual(nameof(fd.RstRcvd), fd.RstRcvd);
            Assert.AreEqual(nameof(fd.RstSent), fd.RstSent);
            Assert.AreEqual(nameof(fd.Comments), fd.Comments);
        }

        [TestMethod]
        public void SaveQso_HappyPass()
        {
            var model = GetFilledLoggerViewModel();

            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SaveButton));

            var fd = model._currentFormData;
            Assert.IsTrue(string.IsNullOrEmpty(fd.Callsign));
            Assert.IsTrue(string.IsNullOrEmpty(fd.RstRcvd));
            Assert.IsTrue(string.IsNullOrEmpty(fd.RstSent));
            Assert.IsTrue(string.IsNullOrEmpty(fd.Operator));
            Assert.IsTrue(string.IsNullOrEmpty(fd.Comments));
        }

        [TestMethod]
        public void SaveQso_NoCallsign()
        {
            var model = GetFilledLoggerViewModel();

            // a callsign is mandatory
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Callsign, string.Empty));
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SaveButton));

            var fd = model._currentFormData;
            Assert.IsFalse(string.IsNullOrEmpty(fd.RstRcvd));
            Assert.IsFalse(string.IsNullOrEmpty(fd.RstSent));
            Assert.IsFalse(string.IsNullOrEmpty(fd.Operator));
            Assert.IsFalse(string.IsNullOrEmpty(fd.Comments));
        }

        [TestMethod]
        public void WipeButtonClicked()
        {
            var loggerModel = GetFilledLoggerViewModel();
            var textInputModel = new TextInputPanelViewModel();
            
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.WipeButton));

            var fd = loggerModel._currentFormData;
            Assert.IsTrue(string.IsNullOrEmpty(fd.Callsign));
            Assert.IsTrue(string.IsNullOrEmpty(fd.RstRcvd));
            Assert.IsTrue(string.IsNullOrEmpty(fd.RstSent));
            Assert.IsTrue(string.IsNullOrEmpty(fd.Operator));
            Assert.IsTrue(string.IsNullOrEmpty(fd.Comments));

            Assert.IsTrue(string.IsNullOrEmpty(textInputModel.Callsign));
            Assert.IsTrue(string.IsNullOrEmpty(textInputModel.RstRcvd));
            Assert.IsTrue(string.IsNullOrEmpty(textInputModel.RstSent));
            Assert.IsTrue(string.IsNullOrEmpty(textInputModel.Operator));
            Assert.IsTrue(string.IsNullOrEmpty(textInputModel.Comments));
        }
    }
}
