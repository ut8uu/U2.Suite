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
using U2.Contracts;

namespace U2.Logger.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        private TextInputPanelViewModel GetFilledLoggerViewModel()
        {
            var model = new TextInputPanelViewModel();
            model.Callsign = nameof(model.Callsign);
            model.RstSent = nameof(model.RstSent);
            model.RstRcvd = nameof(model.RstRcvd);
            model.Operator = nameof(model.Operator);
            model.Comments = nameof(model.Comments);
            model.Mode = RadioMode.FM;
            model.Band = RadioBandName.B10m;
            model.Frequency = "28.5";
            model.Timestamp = DateTime.UtcNow;

            return model;
        }


        [TestMethod]
        public void SaveQso_HappyPass()
        {
            var model = GetFilledLoggerViewModel();
            var mainVM = new MainWindowViewModel();

            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SaveButton));

            Assert.IsTrue(string.IsNullOrEmpty(model.Callsign));
            Assert.IsTrue(string.IsNullOrEmpty(model.Operator));
            Assert.IsTrue(string.IsNullOrEmpty(model.Comments));
        }

        [TestMethod]
        public void SaveQso_NoCallsign()
        {
            var model = GetFilledLoggerViewModel();

            // a callsign is mandatory
            model.Callsign = string.Empty;
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SaveButton));

            Assert.IsFalse(string.IsNullOrEmpty(model.RstRcvd));
            Assert.IsFalse(string.IsNullOrEmpty(model.RstSent));
            Assert.IsFalse(string.IsNullOrEmpty(model.Operator));
            Assert.IsFalse(string.IsNullOrEmpty(model.Comments));
        }

        [TestMethod]
        public void WipeButtonClicked()
        {
            var model = GetFilledLoggerViewModel();
            
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.WipeButton));

            Assert.IsTrue(string.IsNullOrEmpty(model.Callsign));
            Assert.IsTrue(string.IsNullOrEmpty(model.Operator));
            Assert.IsTrue(string.IsNullOrEmpty(model.Comments));
        }
    }
}
