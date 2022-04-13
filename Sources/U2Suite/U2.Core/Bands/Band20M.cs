using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band20M : RadioBand
{
    public Band20M()
    {
        Name = RadioBandName.B20m;
        BeginMhz = 14.000m;
        EndMhz = 14.350m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B20m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 14.000m,
                EndMhz = 14.070m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 14.070m,
                EndMhz = 14.099m,
                Modes = RadioMode.NarrowBandModes,
            },
            new SubBand
            {
                BeginMhz = 14.101m,
                EndMhz = 14.300m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
