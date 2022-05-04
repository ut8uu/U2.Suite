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
