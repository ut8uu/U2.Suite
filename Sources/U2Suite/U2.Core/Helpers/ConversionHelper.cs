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
            new Band80M(),
            new Band60M(),
            new Band40M(),
            new Band30M(),
            new Band20M(),
            new Band17M(),
            new Band15M(),
            new Band12M(),
            new Band10M(),
            new Band6M(),
            new Band4M(),
            new Band2M(),
            new Band70CM(),
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
        /// Converts given mode to a default report in this mode.
        /// Digital modes are not covered - no default report is there.
        /// </summary>
        /// <param name="modeName">A name of the mode to be processed.</param>
        /// <returns>Returns default report for mode or emmpty string if not applicable.</returns>
        public static string ModeToDefaultReport(string modeName)
        {
            if (modeName.Equals(RadioMode.CW, StringComparison.InvariantCultureIgnoreCase))
            {
                return "599";
            }
            if (modeName.Equals(RadioMode.SSB, StringComparison.InvariantCultureIgnoreCase))
            {
                return "59";
            }
            if (modeName.Equals(RadioMode.FM, StringComparison.InvariantCultureIgnoreCase))
            {
                return "595";
            }
            return string.Empty;
        }

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
        /// <param name="frequencyMhz">A frequency in kilohertz.</param>
        /// <returns>Returns object of type <see cref="RadioBandType"/>.</returns>
        public static string FrequencyToBandName(double frequencyMhz)
        {
            var band = AllBands.FirstOrDefault(b =>
                b.BeginMhz <= frequencyMhz && b.EndMhz > frequencyMhz);
            if (band == null)
            {
                return string.Empty;
            }

            return band.Name;
        }

        /// <summary>
        /// Fixes value of the report based on the given mode.
        /// </summary>
        /// <param name="modeName">A name of the current mode</param>
        /// <param name="rst">An RST to be fixed.</param>
        /// <returns>Returns the updated or original RST.</returns>
        #warning TODO Implement this
        public static string FixRst(string modeName, string rst)
        {
            if (modeName == RadioMode.CW)
            {

            }
            else if (modeName == RadioMode.SSB)
            {

            }
            else if (modeName == RadioMode.FM)
            {

            }

            return rst;
        }

    }
}
