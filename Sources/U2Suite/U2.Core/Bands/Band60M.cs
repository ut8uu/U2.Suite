using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band60M : RadioBand
{
    public Band60M()
    {
        Name = RadioBandName.B60m;
        BeginMhz = 5.3515m;
        EndMhz = 5.3665m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B60m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 5.3515m,
                EndMhz = 5.354m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 5.354m,
                EndMhz = 5.366m,
                Modes = RadioMode.NarrowBandModes,
            },
        };
    }
}
