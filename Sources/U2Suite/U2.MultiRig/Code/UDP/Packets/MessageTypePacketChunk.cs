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
using System.Diagnostics;

namespace U2.MultiRig;

public static class MessageTypes
{
    public const char Answer = 'A';
    public const char Information = 'I';
    public const char Request = 'R';
    public const char Status = 'S';
}

public sealed class MessageTypePacketChunk : UdpPacketChunk<char>
{
    public MessageTypePacketChunk(char data)
        : base(PacketChunkType.MessageType,
            RigUdpMessengerPacket.MessageTypeStart, RigUdpMessengerPacket.MessageTypeLen,
            new[] { (byte)data })
    {
    }

    public static MessageTypePacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.MessageTypeStart,
            RigUdpMessengerPacket.MessageTypeLen);
        return new MessageTypePacketChunk((char)chunkData[0]);
    }

    internal override byte[] GetBytesFromValue()
    {
        return new[] { (byte)Value };
    }

    internal override char GetValueFromBytes(byte[] data)
    {
        Debug.Assert(data.Length > 0);
        return (char)data.First();
    }

    public override bool IsValid
    {
        get
        {
            var allowedChars = new[] { 'R', 'A', 'I', 'S' };
            return allowedChars.Contains(Value);
        }
    }
}