using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band10M : RadioBand
{
    public Band10M()
    {
        Name = RadioBandName.B10m;
        BeginMhz = 28.000m;
        EndMhz = 29.700m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B10m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 28.000m,
                EndMhz = 28.070m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 28.070m,
                EndMhz = 28.190m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 28.225m,
                EndMhz = 29.700m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
