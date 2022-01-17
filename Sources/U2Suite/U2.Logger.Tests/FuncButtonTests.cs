using System;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class FuncButtonTests
    {
        private ApplicationButton? _button;

        private void AcceptButtonClickedMessage(ButtonClickedMessage message)
        {
            _button = message.Button;
        }

        [TestInitialize]
        public void InitTest()
        {
            _button = null;

            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
        }

        [TestMethod]
        [DataRow(ApplicationButton.SaveButton)]
        [DataRow(ApplicationButton.WipeButton)]
        public void ReportClickedButton(ApplicationButton button)
        {
            var model = new FuncButtonsPanelViewModel();
            switch (button)
            {
                case ApplicationButton.WipeButton:
                    model.Wipe();
                    break;
                case ApplicationButton.SaveButton:
                    model.Save();
                    break;
                default:
                    throw new ArgumentException($"Unexpected button {button}");
            }

            Assert.IsTrue(_button.HasValue);
            Assert.AreEqual(button, _button);
        }
    }
}
