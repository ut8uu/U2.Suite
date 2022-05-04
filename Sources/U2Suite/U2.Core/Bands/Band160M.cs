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

public class Band160M : RadioBand
{
    public Band160M()
    {
        Name = RadioBandName.B160m;
        BeginMhz = 1.810m;
        EndMhz = 2.000m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B160m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 1.8100m,
                EndMhz = 1.8380m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 1.8380m,
                EndMhz = 1.840m,
                Modes = RadioMode.NarrowBandModes,
            },
            new SubBand
            {
                BeginMhz = 1.840m,
                EndMhz = 2.000m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
