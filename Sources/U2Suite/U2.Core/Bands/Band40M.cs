using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band40M : RadioBand
    {
        public Band40M()
        {
            Name = RadioBandName.B40m;
            BeginMhz = 7.000;
            EndMhz = 7.200;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B40m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 7.000,
                    EndMhz = 7.040,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 7.040,
                    EndMhz = 7.060,
                    Modes = RadioMode.NarrowBandModes,
                },
                new SubBand
                {
                    BeginMhz = 7.060,
                    EndMhz = 7.200,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}