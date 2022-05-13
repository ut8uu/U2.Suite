﻿/* 
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

namespace U2.MultiRig.Tests
{
    internal class TestHelper
    {
        public const string MagicNumberHexStr = "ABBA1105";
        public static readonly byte[] MagicNumberByteArray = new byte[] {0xAB, 0xBA, 0x11, 0x05};
        public const string UnknownMagicNumberHexStr = "ABADBABA";
        public const string UnixEpochTimestampHexStr = "0080B5F7F57F9F48";

        public const string UdpPacketGoodValue = $"{MagicNumberHexStr}{UnixEpochTimestampHexStr}";
        public const string UdpPacketUnknownMagicNumber = $"{UnknownMagicNumberHexStr}{UnixEpochTimestampHexStr}";
    }
}
