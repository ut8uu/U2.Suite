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
using U2.MultiRig.Code.Exceptions;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public sealed class MessageTypePacketChunk : UdpPacketChunk<char>
{
    public MessageTypePacketChunk(byte[] data) 
        : base(PacketChunkType.MessageType,
            RigUdpMessengerPacket.MessageTypeStart, RigUdpMessengerPacket.MessageTypeLen, 
            data)
    {
    }

    internal override byte[] GetBytesFromValue()
    {
        return new[]{ (byte)Value };
    }

    internal override char GetValueFromBytes(byte[] data)
    {
        var chunkData = GetBytes(data, StartPosition, ChunkSize);
        try
        {
            return (char)chunkData[0];
        }
        catch (ArgumentException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToTimestampError(chunkData));
        }
    }

    public override bool IsValid
    {
        get
        {
            var allowedChars = new[] {'R', 'A', 'I', 'S'};
            return allowedChars.Contains(Value);
        }
    }
}