/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
