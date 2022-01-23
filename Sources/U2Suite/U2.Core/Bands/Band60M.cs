using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band60M : RadioBand
    {
        public Band60M()
        {
            Name = RadioBandName.B60m;
            BeginMhz = 5.3515;
            EndMhz = 5.3665;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B60m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 5.3515,
                    EndMhz = 5.354,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 5.354,
                    EndMhz = 5.366,
                    Modes = RadioMode.NarrowBandModes,
                },
            };
        }
    }
}