using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band10M : RadioBand
    {
        public Band10M()
        {
            Name = RadioBandName.B10m;
            BeginMhz = 28.000;
            EndMhz = 29.700;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B10m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 28.000,
                    EndMhz = 28.070,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 28.070,
                    EndMhz = 28.190,
                    Modes = RadioMode.NarrowBandDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 28.225,
                    EndMhz = 29.700,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}