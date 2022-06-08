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
using U2.Contracts;
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
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = TimestampPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.UnixEpochTimestampHexStr);
        Assert.Equal(TestHelper.UnixEpochTimestamp, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));

        chunk = new TimestampPacketChunk(TestHelper.UnixEpochTimestamp);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.UnixEpochTimestamp, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Fact]
    public void DataLength()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = DataLengthPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.DataLengthHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.DataLength, chunk.Value);

        chunk = new DataLengthPacketChunk(TestHelper.DataLength);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.DataLength, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Fact]
    public void SenderId()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = SenderIdPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.SenderIdHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.SenderId, chunk.Value);

        chunk = new SenderIdPacketChunk(TestHelper.SenderId);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.SenderId, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Fact]
    public void ReceiverId()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = ReceiverIdPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.ReceiverIdHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.ReceiverId, chunk.Value);

        chunk = new ReceiverIdPacketChunk(TestHelper.ReceiverId);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.ReceiverId, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Fact]
    public void MessageId()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = MessageIdPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.MessageIdHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.MessageId, chunk.Value);

        chunk = new MessageIdPacketChunk(TestHelper.MessageId);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.MessageId, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Fact]
    public void Checksum()
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        var chunk = ChecksumPacketChunk.FromUdpPacket(data);
        var expectedBytes = ByteFunctions.HexStrToBytes(TestHelper.ChecksumHexStr);
        var actualBytes = chunk.GetBytesFromValue();
        Assert.True(expectedBytes.SequenceEqual(actualBytes));
        Assert.Equal(TestHelper.Checksum, chunk.Value);

        chunk = new ChecksumPacketChunk(TestHelper.Checksum);
        Assert.True(chunk.IsValid);
        Assert.Equal(TestHelper.Checksum, chunk.Value);
        Assert.True(expectedBytes.SequenceEqual(chunk.GetBytesFromValue()));
    }

    [Theory]
    [InlineData('R', true)]
    [InlineData('A', true)]
    [InlineData('I', true)]
    [InlineData('S', true)]
    [InlineData('X', false)]
    public void MessageType(char type, bool isValid)
    {
        var data = ByteFunctions.HexStrToBytes(TestHelper.UdpPacketGoodValue);
        data[RigUdpMessengerPacket.MessageTypeStart] = (byte)type;
        var chunk = MessageTypePacketChunk.FromUdpPacket(data);
        Assert.Equal(isValid, chunk.IsValid);
        Assert.Equal(type, chunk.Value);

        chunk = new MessageTypePacketChunk(type);
        Assert.Equal(isValid, chunk.IsValid);
        Assert.Equal(type, chunk.Value);
        Assert.True(new[] { (byte)type }.SequenceEqual(chunk.GetBytesFromValue()));

    }

    [Fact]
    public void EncodeDecodeUdpPacket()
    {
        const int expectedValue = 14246015;
        var packet1 = UdpPacketFactory.CreateSingleParameterReportingPacket(1,
            KnownIdentifiers.U2MultiRig, KnownIdentifiers.U2Logger,
            RigParameter.FreqB, expectedValue);

        var packet2 = RigUdpMessengerPacket.FromUdpPacket(packet1.GetBytes());

        Assert.NotNull(packet2.MessageId);
        Assert.NotNull(packet2.Checksum);
        Assert.NotNull(packet2.MessageId);
        Assert.NotNull(packet2.MessageType);
        Assert.NotNull(packet2.ReceiverId);
        Assert.NotNull(packet2.SenderId);
        Assert.NotNull(packet2.CommandId);
        Assert.NotNull(packet2.Data);
        Assert.NotNull(packet2.DataLength);
        Assert.NotNull(packet2.MagicNumber);
        Assert.NotNull(packet2.Timestamp);

        Assert.Equal(packet1.Checksum.Value, packet2.Checksum.Value);
        Assert.Equal(packet1.Timestamp.Value, packet2.Timestamp.Value);
        Assert.Equal(packet1.SenderId.Value, packet2.SenderId.Value);
        Assert.Equal(packet1.ReceiverId.Value, packet2.ReceiverId.Value);
        Assert.Equal(packet1.CommandId.Value, packet2.CommandId.Value);
        Assert.Equal(packet1.MessageId.Value, packet2.MessageId.Value);
        Assert.Equal(packet1.MessageType.Value, packet2.MessageType.Value);
        Assert.Equal(packet1.DataLength.Value, packet2.DataLength.Value);
        Assert.True(packet1.Data.Value.SequenceEqual(packet2.Data.Value));
    }
}
