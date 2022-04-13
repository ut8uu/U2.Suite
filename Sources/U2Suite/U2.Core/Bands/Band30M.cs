using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band30M : RadioBand
{
    public Band30M()
    {
        Name = RadioBandName.B30m;
        BeginMhz = 10.100m;
        EndMhz = 10.150m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B30m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 10.100m,
                EndMhz = 10.130m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 10.130m,
                EndMhz = 10.150m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
        };
    }
}
