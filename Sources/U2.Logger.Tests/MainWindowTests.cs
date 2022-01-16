using System;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class MainWindowTests
    {

        [TestMethod]
        public void ReportChangedText()
        {
            var model = new LoggerMainWindowViewModel();
            var fd = model._currentFormData;

            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Callsign, nameof(fd.Callsign)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Operator, nameof(fd.Operator)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.RstReceived, nameof(fd.RstRcvd)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.RstSent, nameof(fd.RstSent)));
            Messenger.Default.Send(new TextChangedMessage(this, ApplicationTextBox.Comments, nameof(fd.Comments)));

            fd = model._currentFormData;
            Assert.AreEqual(nameof(fd.Callsign), fd.Callsign);
            Assert.AreEqual(nameof(fd.Operator), fd.Operator);
            Assert.AreEqual(nameof(fd.RstRcvd), fd.RstRcvd);
            Assert.AreEqual(nameof(fd.RstSent), fd.RstSent);
            Assert.AreEqual(nameof(fd.Comments), fd.Comments);
        }
    }
}
