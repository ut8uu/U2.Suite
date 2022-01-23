using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band17M : RadioBand
    {
        public Band17M()
        {
            Name = RadioBandName.B17m;
            BeginMhz = 18.068;
            EndMhz = 18.168;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B17m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 18.068,
                    EndMhz = 18.095,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 18.095,
                    EndMhz = 18.109,
                    Modes = RadioMode.NarrowBandDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 18.111,
                    EndMhz = 18.168,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}