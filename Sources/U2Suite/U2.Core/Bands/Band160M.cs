﻿using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band160M : RadioBand
    {
        public Band160M()
        {
            Name = RadioBandName.B160m;
            BeginMhz = 1.810;
            EndMhz = 2.000;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B160m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 1.8100,
                    EndMhz = 1.8380,
                    Modes = RadioMode.CwModes,
                },
                new SubBand
                {
                    BeginMhz = 1.8380,
                    EndMhz = 1.840,
                    Modes = RadioMode.NarrowBandModes,
                },
                new SubBand
                {
                    BeginMhz = 1.840,
                    EndMhz = 2.000,
                    Modes = RadioMode.AllModes,
                },
            };
        }
    }
}