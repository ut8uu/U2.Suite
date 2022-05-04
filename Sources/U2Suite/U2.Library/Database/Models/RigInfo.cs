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

using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Library
{
    public sealed class RigInfo
    {
        public RigInfo() { }

        public string Manufacturer { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Modes { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Power { get; set; } = default!;
        public string Dimensions { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string Weight { get; set; } = default!;
    }
}
