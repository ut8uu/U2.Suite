using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band70CM : RadioBand
    {
        public Band70CM()
        {
            Name = RadioBandName.B70cm;
            BeginMhz = 430.000;
            EndMhz = 440.000;
            Group = RadioBandGroup.UHF;
            Type = RadioBandType.B70cm;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 430.000,
                    EndMhz = 431.975,
                    Modes = RadioMode.AllModes,
                },
                new SubBand
                {
                    BeginMhz = 431.975,
                    EndMhz = 432.100,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 432.100,
                    EndMhz = 432.400,
                    Modes = RadioMode.CwSsbModes,
                },
                new SubBand
                {
                    BeginMhz = 432.500,
                    EndMhz = 432.975,
                    Modes = RadioMode.AllModes,
                },
                new SubBand
                {
                    BeginMhz = 433.000,
                    EndMhz = 433.575,
                    Modes = RadioMode.FmDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 433.600,
                    EndMhz = 434.981,
                    Modes = RadioMode.AllModes,
                },
                new SubBand
                {
                    BeginMhz = 435.000,
                    EndMhz = 438.000,
                    Modes = RadioMode.SatelliteModes,
                },
                new SubBand
                {
                    BeginMhz = 438.000,
                    EndMhz = 440.000,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}