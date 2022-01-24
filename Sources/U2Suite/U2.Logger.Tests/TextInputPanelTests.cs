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
