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
using U2.MultiRig.Code;
using U2.MultiRig.Code.Exceptions;
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
    public void MagicNumber_HappyPass()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue); 
        var magicNumberChunk = new MagicNumberPacketChunk(data);
        Assert.Equal(TestHelper.MagicNumberByteArray, magicNumberChunk.Value);
    }

    [Fact]
    public void MagicNumber_IncorrectSignature()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketUnknownMagicNumber);
        var magicNumber = new MagicNumberPacketChunk(data);
        Assert.False(magicNumber.IsValid);
    }

    [Fact]
    public void GetTimestamp()
    {
        var data = ByteFunctions.HexStrToBytes($"{TestHelper.UdpPacketGoodValue}");
        var timestamp = new TimestampPacketChunk(data);
        Assert.Equal(DateTime.UnixEpoch, timestamp.Value);
    }

    [Fact]
    public void SenderId()
    {
        var data = ByteFunctions.HexStrToBytes($"{TestHelper.UdpPacketGoodValue}");
        var sender = new SenderIdPacketChunk(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.SenderIdHexStr);
        var actualBytes = sender.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(256 + 2 /* 0x0102 */, sender.Value);
    }

    [Fact]
    public void ReceiverId()
    {
        var data = ByteFunctions.HexStrToBytes($"{TestHelper.UdpPacketGoodValue}");
        var receiver = new ReceiverIdPacketChunk(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.ReceiverIdHexStr);
        var actualBytes = receiver.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(3 * 256 + 4 /* 0x0304 */, receiver.Value);
    }

    [Fact]
    public void MessageId()
    {
        var data = ByteFunctions.HexStrToBytes($"{TestHelper.UdpPacketGoodValue}");
        var chunk = new MessageIdPacketChunk(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.MessageIdHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.MessageId /* 0x0511 */, chunk.Value);
    }

    [Theory]
    [InlineData('R', true)]
    [InlineData('A', true)]
    [InlineData('I', true)]
    [InlineData('S', true)]
    [InlineData('X', false)]
    public void MessageType(char type, bool isValid)
    {
        var data = ByteFunctions.HexStrToBytes($"{TestHelper.UdpPacketGoodValue}");
        data[RigUdpMessengerPacket.MessageTypeStart] = (byte) type;
        var chunk = new MessageTypePacketChunk(data);
        Assert.Equal(isValid, chunk.IsValid);
        Assert.Equal(type, chunk.Value);
    }
}
