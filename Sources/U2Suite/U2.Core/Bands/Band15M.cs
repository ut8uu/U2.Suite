using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band15M : RadioBand
    {
        public Band15M()
        {
            Name = RadioBandName.B15m;
            BeginMhz = 21.000;
            EndMhz = 21.450;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B15m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 21.000,
                    EndMhz = 21.070,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 21.070,
                    EndMhz = 21.149,
                    Modes = RadioMode.NarrowBandDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 21.151,
                    EndMhz = 21.450,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}