using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band4M : RadioBand
    {
        public Band4M()
        {
            Name = RadioBandName.B4m;
            BeginMhz = 70.000;
            EndMhz = 70.500;
            Group = RadioBandGroup.VHF;
            Type = RadioBandType.B4m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 70.000,
                    EndMhz = 70.100,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 70.100,
                    EndMhz = 70.250,
                    Modes = RadioMode.CwSsbModes,
                },
                new SubBand
                {
                    BeginMhz = 70.250,
                    EndMhz = 70.254,
                    Modes = RadioMode.AmFmModes,
                },
                new SubBand
                {
                    BeginMhz = 70.254,
                    EndMhz = 70.500,
                    Modes = RadioMode.FmDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 50.500,
                    EndMhz = 54.000,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}