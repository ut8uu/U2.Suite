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
        public static IEnumerable<object[]> BandToFreqData =>
            new[]
            {
                new object[] { RadioBandName.B160m, 1.810m },
                new object[] { RadioBandName.B80m, 3.500m },
                new object[] { RadioBandName.B60m, 5.3515m },
                new object[] { RadioBandName.B40m, 7.000m },
                new object[] { RadioBandName.B30m, 10.100m },
                new object[] { RadioBandName.B20m, 14.000m },
                new object[] { RadioBandName.B17m, 18.068m },
                new object[] { RadioBandName.B15m, 21.000m },
                new object[] { RadioBandName.B12m, 24.890m },
                new object[] { RadioBandName.B10m, 28.000m },
                new object[] { RadioBandName.B6m, 50.000m },
                new object[] { RadioBandName.B4m, 70.000m },
                new object[] { RadioBandName.B2m, 144.000m },
            };

        [TestMethod]
        [DynamicData(nameof(BandToFreqData))]
        public void BandToFreq(string bandName, decimal expectedFreqMhz)
        {
            var freq = ConversionHelper.BandNameToFrequency(bandName);
            Assert.AreEqual(expectedFreqMhz, freq);
        }

        public static IEnumerable<object[]> FreqToBandData =>
            new[]
            {
                new object[] { 1.810m, RadioBandName.B160m },
                new object[] { 1.999m, RadioBandName.B160m },
                new object[] { 3.501m, RadioBandName.B80m },
                new object[] { 5.353m, RadioBandName.B60m },
                new object[] { 7.001m, RadioBandName.B40m },
                new object[] { 10.101m, RadioBandName.B30m },
                new object[] { 14.001m, RadioBandName.B20m },
                new object[] { 18.101m, RadioBandName.B17m },
                new object[] { 21.001m, RadioBandName.B15m },
                new object[] { 24.891m, RadioBandName.B12m },
                new object[] { 28.101m, RadioBandName.B10m },
                new object[] { 50.001m, RadioBandName.B6m },
                new object[] { 70.001m, RadioBandName.B4m },
                new object[] { 144.001m, RadioBandName.B2m },
                new object[] { 432.001m, RadioBandName.B70cm },
            };

        [TestMethod]
        [DynamicData(nameof(FreqToBandData))]
        public void FreqToBand_Success(decimal freqMhz, string expectedBand)
        {
            var band = ConversionHelper.FrequencyToBandName(freqMhz);
            Assert.AreEqual(expectedBand, band);
        }

        public static IEnumerable<object[]> BandAndModeToFreqData =>
            new[]
            {
                new object[] { RadioBandName.B160m, RadioMode.CW, 1.810m },
                new object[] { RadioBandName.B160m, RadioMode.PSK, 1.838m },
                new object[] { RadioBandName.B160m, RadioMode.RTTY, 1.838m },
                new object[] { RadioBandName.B160m, RadioMode.DIGITALVOICE, 1.840m },
                new object[] { RadioBandName.B160m, RadioMode.SSB, 1.840m },
                new object[] { RadioBandName.B160m, RadioMode.FM, 1.840m },
                new object[] { RadioBandName.B160m, "unknown", 1.810m },
            };

        [TestMethod]
        [DynamicData(nameof(BandAndModeToFreqData))]
#warning TODO Add the rest cases for all bands
        public void BandAndModeToFreq(string bandName, string modeName, decimal expectedFrequency)
        {
            var frequency = ConversionHelper.BandNameAndModeToFrequency(bandName, modeName);
            Assert.AreEqual(expectedFrequency, frequency);
        }
    }
}
