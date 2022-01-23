using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band12M : RadioBand
    {
        public Band12M()
        {
            Name = RadioBandName.B12m;
            BeginMhz = 24.890;
            EndMhz = 24.990;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B12m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 24.890,
                    EndMhz = 24.915,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 24.915,
                    EndMhz = 24.929,
                    Modes = RadioMode.NarrowBandDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 24.931,
                    EndMhz = 24.990,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}