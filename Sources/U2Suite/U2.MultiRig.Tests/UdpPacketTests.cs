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
using U2.MultiRig.Code;
using U2.MultiRig.Code.UDP;
using Xunit;

namespace U2.MultiRig.Tests;

public class UdpPacketTests
{
    [Fact]
    public void TooShortData()
    {
        var data = Encoding.UTF8.GetBytes("x");
        Assert.Throws<UdpPacketException>(() => new MagicNumberPacketChunk(data));
    }

    [Fact]
    public void GetMagicNumber()
    {
        var data = ByteFunctions.HexStrToBytes("30313233343536"); //0123456 as Hex
        var magicNumber = new MagicNumberPacketChunk(data);
        Assert.Equal("30313233", magicNumber.Value);
        Assert.Equal(Encoding.UTF8.GetBytes("0123"), magicNumber.GetBytesFromValue());
    }
}
