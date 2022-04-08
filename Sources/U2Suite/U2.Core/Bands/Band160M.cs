using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band160M : RadioBand
{
    public Band160M()
    {
        Name = RadioBandName.B160m;
        BeginMhz = 1.810m;
        EndMhz = 2.000m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B160m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 1.8100m,
                EndMhz = 1.8380m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 1.8380m,
                EndMhz = 1.840m,
                Modes = RadioMode.NarrowBandModes,
            },
            new SubBand
            {
                BeginMhz = 1.840m,
                EndMhz = 2.000m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
