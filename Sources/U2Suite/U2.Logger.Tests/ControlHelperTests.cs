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
