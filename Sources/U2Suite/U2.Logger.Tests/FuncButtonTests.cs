/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
