using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band4M : RadioBand
{
    public Band4M()
    {
        Name = RadioBandName.B4m;
        BeginMhz = 70.000m;
        EndMhz = 70.500m;
        Group = RadioBandGroup.VHF;
        Type = RadioBandType.B4m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 70.000m,
                EndMhz = 70.100m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 70.100m,
                EndMhz = 70.250m,
                Modes = RadioMode.CwSsbModes,
            },
            new SubBand
            {
                BeginMhz = 70.250m,
                EndMhz = 70.254m,
                Modes = RadioMode.AmFmModes,
            },
            new SubBand
            {
                BeginMhz = 70.254m,
                EndMhz = 70.500m,
                Modes = RadioMode.FmDigitalModes,
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
