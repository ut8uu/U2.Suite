using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band2M : RadioBand
    {
        public Band2M()
        {
            Name = RadioBandName.B2m;
            BeginMhz = 144.000;
            EndMhz = 146.000;
            Group = RadioBandGroup.VHF;
            Type = RadioBandType.B2m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 144.000,
                    EndMhz = 144.025,
                    Modes = RadioMode.AllModes,
                },
                new SubBand
                {
                    BeginMhz = 144.025,
                    EndMhz = 144.150,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 144.150,
                    EndMhz = 144.270,
                    Modes = RadioMode.CwSsbModes,
                },
                new SubBand
                {
                    BeginMhz = 144.500,
                    EndMhz = 144.794,
                    Modes = RadioMode.AllModes,
                },
                new SubBand
                {
                    BeginMhz = 144.794,
                    EndMhz = 145.806,
                    Modes = RadioMode.FmDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 145.806,
                    EndMhz = 146.000,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}