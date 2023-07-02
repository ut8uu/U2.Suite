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
        [TestInitialize]
        public void InitTest()
        {
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
