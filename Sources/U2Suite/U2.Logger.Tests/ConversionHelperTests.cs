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
        [DataRow(RadioBandType.B160m, 1810.0)]
        public void BandToFreq(RadioBandType type, double expectedFreqKhz)
        {
            var freq = ConversionHelper.BandToFrequency(type);
            Assert.AreEqual(expectedFreqKhz, freq);
        }

        [TestMethod]
        [DataRow(1810.0, RadioBandType.B160m)]
        [DataRow(1999.999, RadioBandType.B160m)]
        public void FreqToBand_Success(double freqKhz, RadioBandType expectedBand)
        {
            var band = ConversionHelper.FrequencyToBand(freqKhz);
            Assert.AreEqual(expectedBand, band);
        }
    }
}
