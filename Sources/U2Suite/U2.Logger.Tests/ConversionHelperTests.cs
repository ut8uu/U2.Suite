using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;
using U2.Core;

namespace U2.Logger.Tests
{
    [TestClass]
    public class ConversionHelperTests
    {
        [TestMethod]
        [DataRow(RadioBandName.B160m, 1.810)]
        public void BandToFreq(string bandName, double expectedFreqMhz)
        {
            var freq = ConversionHelper.BandNameToFrequency(bandName);
            Assert.AreEqual(expectedFreqMhz, freq);
        }

        [TestMethod]
        [DataRow(1.810, RadioBandName.B160m)]
        [DataRow(1.999, RadioBandName.B160m)]
        public void FreqToBand_Success(double freqMhz, string expectedBand)
        {
            var band = ConversionHelper.FrequencyToBandName(freqMhz);
            Assert.AreEqual(expectedBand, band);
        }

        [TestMethod]
        [DataRow(RadioBandName.B160m, RadioMode.CW, 1.81)]
        [DataRow(RadioBandName.B160m, RadioMode.PSK, 1.838)]
        [DataRow(RadioBandName.B160m, RadioMode.RTTY, 1.838)]
        [DataRow(RadioBandName.B160m, RadioMode.DIGITALVOICE, 1.840)]
        [DataRow(RadioBandName.B160m, RadioMode.SSB, 1.840)]
        [DataRow(RadioBandName.B160m, RadioMode.FM, 1.840)]
        [DataRow(RadioBandName.B160m, "unknown", 1.81)]
        public void BandAndModeToFreq(string bandName, string modeName, double expectedFrequency)
        {
            var frequency = ConversionHelper.BandNameAndModeToFrequency(bandName, modeName);
            Assert.AreEqual(expectedFrequency, frequency, 0.0000001);
        }
    }
}
