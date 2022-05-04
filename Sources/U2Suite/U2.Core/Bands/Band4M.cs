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

public class Band4M : RadioBand
{
    public Band4M()
    {
        Name = RadioBandName.B4m;
        BeginMhz = 70.000m;
        EndMhz = 70.500m;
        Group = RadioBandGroup.VHF;
        Type = RadioBandType.B4m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 70.000m,
                EndMhz = 70.100m,
                Modes = RadioMode.CwModes,
            },
            new SubBand
            {
                BeginMhz = 70.100m,
                EndMhz = 70.250m,
                Modes = RadioMode.CwSsbModes,
            },
            new SubBand
            {
                BeginMhz = 70.250m,
                EndMhz = 70.254m,
                Modes = RadioMode.AmFmModes,
            },
            new SubBand
            {
                BeginMhz = 70.254m,
                EndMhz = 70.500m,
                Modes = RadioMode.FmDigitalModes,
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
