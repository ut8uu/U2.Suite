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

public class Band40M : RadioBand
{
    public Band40M()
    {
        Name = RadioBandName.B40m;
        BeginMhz = 7.000m;
        EndMhz = 7.200m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B40m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 7.000m,
                EndMhz = 7.040m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 7.040m,
                EndMhz = 7.060m,
                Modes = RadioMode.NarrowBandModes,
            },
            new SubBand
            {
                BeginMhz = 7.060m,
                EndMhz = 7.200m,
                Modes = RadioMode.AllModes,
            },
        };
    }
}
