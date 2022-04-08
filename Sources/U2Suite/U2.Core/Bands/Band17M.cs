using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band17M : RadioBand
{
    public Band17M()
    {
        Name = RadioBandName.B17m;
        BeginMhz = 18.068m;
        EndMhz = 18.168m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B17m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 18.068m,
                EndMhz = 18.095m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 18.095m,
                EndMhz = 18.109m,
                Modes = RadioMode.NarrowBandDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 18.111m,
                EndMhz = 18.168m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
