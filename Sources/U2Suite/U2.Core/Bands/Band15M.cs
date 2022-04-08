using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band15M : RadioBand
{
    public Band15M()
    {
        Name = RadioBandName.B15m;
        BeginMhz = 21.000m;
        EndMhz = 21.450m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B15m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 21.000m,
                EndMhz = 21.070m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 21.070m,
                EndMhz = 21.149m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 21.151m,
                EndMhz = 21.450m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
