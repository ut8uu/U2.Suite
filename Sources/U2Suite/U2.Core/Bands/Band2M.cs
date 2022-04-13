using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band2M : RadioBand
{
    public Band2M()
    {
        Name = RadioBandName.B2m;
        BeginMhz = 144.000m;
        EndMhz = 146.000m;
        Group = RadioBandGroup.VHF;
        Type = RadioBandType.B2m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 144.000m,
                EndMhz = 144.025m,
                Modes = RadioMode.AllModes,
            },
            new SubBand
            {
                BeginMhz = 144.025m,
                EndMhz = 144.150m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 144.150m,
                EndMhz = 144.270m,
                Modes = RadioMode.CwSsbModes,
            },
            new SubBand
            {
                BeginMhz = 144.500m,
                EndMhz = 144.794m,
                Modes = RadioMode.AllModes,
            },
            new SubBand
            {
                BeginMhz = 144.794m,
                EndMhz = 145.806m,
                Modes = RadioMode.FmDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 145.806m,
                EndMhz = 146.000m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
