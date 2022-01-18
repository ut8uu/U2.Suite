using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Converts given band to its most lower frequency.
        /// </summary>
        /// <param name="bandType">A band type to process.</param>
        /// <returns>Returns the most lower frequency of the given band.</returns>
        /// <exception cref="ArgumentException">Thrown when Unspecified is passed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when unknown band is passed.</exception>
        public static double BandToFrequency(RadioBandType bandType)
        {
            if (RadioBandType.Unspecified == bandType)
            {
                throw new ArgumentException($"Band {bandType} not specified.");
            }

            var band = AllBands.FirstOrDefault(b => b.Type == bandType);
            if (band == null)
            {
                throw new ArgumentOutOfRangeException($"Band {bandType} is unknown.");
            }

            return band.BeginKhz;
        }

        /// <summary>
        /// Converts given frequency to an amateur band.
        /// </summary>
        /// <param name="frequencyKhz">A frequency in kilohertz.</param>
        /// <returns>Returns object of type <see cref="RadioBandType"/>.</returns>
        public static RadioBandType FrequencyToBand(double frequencyKhz)
        {
            var band = AllBands.FirstOrDefault(b => b.BeginKhz <= frequencyKhz 
                                                    && b.EndKhz > frequencyKhz);
            if (band == null)
            {
                return RadioBandType.Unspecified;
            }

            return band.Type;
        }
    }

    public class Band160M : RadioBand
    {
        public Band160M()
        {
            Name = RadioBandName.B160m;
            BeginKhz = 1810.0;
            EndKhz = 2000.0;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B160m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginKhz = 1810.0,
                    EndKhz = 1838.0,
                    Modes = new RadioMode[] {RadioMode.CW}
                }
            };
        }
    }
}
