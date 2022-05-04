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
