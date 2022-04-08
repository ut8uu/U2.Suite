using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band70CM : RadioBand
{
    public Band70CM()
    {
        Name = RadioBandName.B70cm;
        BeginMhz = 430.000m;
        EndMhz = 440.000m;
        Group = RadioBandGroup.UHF;
        Type = RadioBandType.B70cm;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 430.000m,
                EndMhz = 431.975m,
                Modes = RadioMode.AllModes,
            },
            new SubBand
            {
                BeginMhz = 431.975m,
                EndMhz = 432.100m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 432.100m,
                EndMhz = 432.400m,
                Modes = RadioMode.CwSsbModes,
            },
            new SubBand
            {
                BeginMhz = 432.500m,
                EndMhz = 432.975m,
                Modes = RadioMode.AllModes,
            },
            new SubBand
            {
                BeginMhz = 433.000m,
                EndMhz = 433.575m,
                Modes = RadioMode.FmDigitalModes,
            },
            new SubBand
            {
                BeginMhz = 433.600m,
                EndMhz = 434.981m,
                Modes = RadioMode.AllModes,
            },
            new SubBand
            {
                BeginMhz = 435.000m,
                EndMhz = 438.000m,
                Modes = RadioMode.SatelliteModes,
            },
            new SubBand
            {
                BeginMhz = 438.000m,
                EndMhz = 440.000m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
