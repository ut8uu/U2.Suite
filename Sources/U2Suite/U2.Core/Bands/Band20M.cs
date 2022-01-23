using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band20M : RadioBand
    {
        public Band20M()
        {
            Name = RadioBandName.B20m;
            BeginMhz = 14.000;
            EndMhz = 14.350;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B20m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 14.000,
                    EndMhz = 14.070,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 14.070,
                    EndMhz = 14.099,
                    Modes = RadioMode.NarrowBandModes,
                },
                new SubBand
                {
                    BeginMhz = 14.101,
                    EndMhz = 14.300,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}