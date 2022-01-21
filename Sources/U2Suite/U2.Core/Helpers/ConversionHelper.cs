using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using U2.Contracts;

namespace U2.Core
{
    public static class ConversionHelper
    {
        public static List<RadioBand> AllBands = new List<RadioBand>
        {
            new Band160M(),
        };

        public static List<RadioMode> AllModes = new List<RadioMode>
        {
            new RadioModeCW(),
            new RadioModeDigitalVoice(),
            new RadioModeFM(),
            new RadioModeRtty(),
            new RadioModeSSB(),
            new RadioModePsk(),
        };

        /// <summary>
        /// Converts given band to its most lower frequency.
        /// </summary>
        /// <param name="bandType">A band type to process.</param>
        /// <returns>Returns the most lower frequency of the given band.</returns>
        /// <exception cref="ArgumentException">Thrown when Unspecified is passed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when unknown band is passed.</exception>
        public static double BandNameToFrequency(string bandName)
        {
            if (string.IsNullOrEmpty(bandName))
            {
                throw new ArgumentException($"Band {bandName} not specified.");
            }

            var band = AllBands.FirstOrDefault(b => b.Name == bandName);
            if (band == null)
            {
                throw new ArgumentOutOfRangeException($"Band {bandName} is unknown.");
            }

            return band.BeginMhz;
        }

        /// <summary>
        /// Converts given band to the frequency of the given band and mode.
        /// </summary>
        /// <param name="bandName">A band type to process.</param>
        /// <param name="modeName">A mode to process.</param>
        /// <returns>Returns the most lower frequency of the given band.</returns>
        /// <exception cref="ArgumentException">Thrown when Unspecified is passed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when unknown band is passed.</exception>
        public static double BandNameAndModeToFrequency(string bandName, string modeName)
        {
            if (string.IsNullOrEmpty(bandName))
            {
                throw new ArgumentException($"Band {bandName} not specified.");
            }

            var band = AllBands.FirstOrDefault(b => b.Name == bandName);
            if (band == null)
            {
                throw new ArgumentOutOfRangeException($"Band {bandName} is unknown.");
            }

            if (string.IsNullOrEmpty(modeName))
            {
                return band.BeginMhz;
            }

            var mode = AllModes.FirstOrDefault(
                m => m.Name.Equals(modeName, StringComparison.InvariantCultureIgnoreCase));
            if (mode == null)
            {
                return band.BeginMhz;
            }

            if (band.SubBands.Any())
            {
                var subBand = band.SubBands.FirstOrDefault(sb => 
                    sb.Modes.Any(m => m.Equals(mode.Type)));
                if (subBand != null)
                {
                    return subBand.BeginMhz;
                }
            }

            return band.BeginMhz;
        }

        /// <summary>
        /// Converts given frequency to an amateur band.
        /// </summary>
        /// <param name="frequencyKhz">A frequency in kilohertz.</param>
        /// <returns>Returns object of type <see cref="RadioBandType"/>.</returns>
        public static string FrequencyToBandName(double frequencyKhz)
        {
            var band = AllBands.FirstOrDefault(b =>
                b.BeginMhz <= frequencyKhz && b.EndMhz > frequencyKhz);
            if (band == null)
            {
                return AllBands.First().Name;
            }

            return band.Name;
        }
    }
}
