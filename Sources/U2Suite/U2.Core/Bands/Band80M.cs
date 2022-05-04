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

public class Band80M : RadioBand
{
    public Band80M()
    {
        Name = RadioBandName.B80m;
        BeginMhz = 3.500m;
        EndMhz = 3.800m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B80m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 3.500m,
                EndMhz = 3.570m,
                Modes = new[] {RadioModeType.CW}
            },
            new SubBand
            {
                BeginMhz = 3.570m,
                EndMhz = 3.600m,
                Modes = new[] {RadioModeType.CW, RadioModeType.PSK, RadioModeType.RTTY,}
            },
            new SubBand
            {
                BeginMhz = 3.600m,
                EndMhz = 3.800m,
                Modes = new[]
                {
                    RadioModeType.CW, RadioModeType.PSK, RadioModeType.DIGITALVOICE,
                    RadioModeType.FM, RadioModeType.RTTY, RadioModeType.SSB,
                }
            },
        };
    }
}
