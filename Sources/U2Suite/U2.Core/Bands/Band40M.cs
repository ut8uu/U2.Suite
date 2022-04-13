using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band40M : RadioBand
{
    public Band40M()
    {
        Name = RadioBandName.B40m;
        BeginMhz = 7.000m;
        EndMhz = 7.200m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B40m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 7.000m,
                EndMhz = 7.040m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 7.040m,
                EndMhz = 7.060m,
                Modes = RadioMode.NarrowBandModes,
            },
            new SubBand
            {
                BeginMhz = 7.060m,
                EndMhz = 7.200m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
