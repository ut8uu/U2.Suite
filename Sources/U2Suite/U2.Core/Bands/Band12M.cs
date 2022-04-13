using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band12M : RadioBand
{
    public Band12M()
    {
        Name = RadioBandName.B12m;
        BeginMhz = 24.890m;
        EndMhz = 24.990m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B12m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 24.890m,
                EndMhz = 24.915m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 24.915m,
                EndMhz = 24.929m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 24.931m,
                EndMhz = 24.990m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
