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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig.Code
{
    public static class Data
    {
        public static readonly int[] BaudRates = {
            110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 56000,
            57600, 115200, 128000, 256000,
        };

        public static readonly int[] DataBits = {5, 6, 7, 8};
        public static readonly decimal[] StopBits = {1m, 1.5m, 2m};

        public enum Parity
        {
            None,
            Odd,
            Even,
            Mark,
            Space,
        }

        public enum RtsMode
        {
            High,
            Low,
            Handshake,
        }

        public enum DtrMode
        {
            High,
            Low,
        }
    }
}
