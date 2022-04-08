using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band6M : RadioBand
{
    public Band6M()
    {
        Name = RadioBandName.B6m;
        BeginMhz = 50.000m;
        EndMhz = 54.000m;
        Group = RadioBandGroup.VHF;
        Type = RadioBandType.B6m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 50.000m,
                EndMhz = 50.100m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 50.100m,
                EndMhz = 50.300m,
                Modes = RadioMode.CwSsbModes,
            },
            new SubBand
            {
                BeginMhz = 50.300m,
                EndMhz = 50.400m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 50.400m,
                EndMhz = 50.500m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 50.500m,
                EndMhz = 54.000m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
