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
        [DataRow(3.501, RadioBandName.B80m)]
        [DataRow(5.352, RadioBandName.B60m)]
        [DataRow(7.001, RadioBandName.B40m)]
        [DataRow(10.101, RadioBandName.B30m)]
        [DataRow(14.001, RadioBandName.B20m)]
        [DataRow(18.101, RadioBandName.B17m)]
        [DataRow(21.001, RadioBandName.B15m)]
        [DataRow(24.891, RadioBandName.B12m)]
        [DataRow(28.001, RadioBandName.B10m)]
        [DataRow(50.001, RadioBandName.B6m)]
        [DataRow(70.001, RadioBandName.B4m)]
        [DataRow(144.001, RadioBandName.B2m)]
        [DataRow(432.001, RadioBandName.B70cm)]
        public void FreqToBand_Success(decimal freqMhz, string expectedBand)
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
#warning TODO Add the rest cases for all bands
        public void BandAndModeToFreq(string bandName, string modeName, decimal expectedFrequency)
        {
            var frequency = ConversionHelper.BandNameAndModeToFrequency(bandName, modeName);
            Assert.AreEqual(expectedFrequency, frequency);
        }
    }
}
