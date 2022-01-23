using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band6M : RadioBand
    {
        public Band6M()
        {
            Name = RadioBandName.B6m;
            BeginMhz = 50.000;
            EndMhz = 54.000;
            Group = RadioBandGroup.VHF;
            Type = RadioBandType.B6m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 50.000,
                    EndMhz = 50.100,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 50.100,
                    EndMhz = 50.300,
                    Modes = RadioMode.CwSsbModes,
                },
                new SubBand
                {
                    BeginMhz = 50.300,
                    EndMhz = 50.400,
                    Modes = RadioMode.NarrowBandDigitalModes,
                },
                new SubBand
                {
                    BeginMhz = 50.400,
                    EndMhz = 50.500,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 50.500,
                    EndMhz = 54.000,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}