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

using System.ComponentModel;
using System.Diagnostics;
using U2.MultiRig.Code;
using U2.MultiRig.Code.Exceptions;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public sealed class MessageIdPacketChunk : UdpPacketChunk<byte>
{
    public MessageIdPacketChunk(byte messageId)
        : base(PacketChunkType.MessageId,
            RigUdpMessengerPacket.MessageIdStart, RigUdpMessengerPacket.MessageIdLen,
            ByteFunctions.MessageIdToBytes(messageId))
    {
    }

    public static MessageIdPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.MessageIdStart,
                RigUdpMessengerPacket.MessageIdLen);
        return new MessageIdPacketChunk(chunkData[0]);
    }

    internal override byte[] GetBytesFromValue()
    {
        return new []{ Value };
    }

    internal override byte GetValueFromBytes(byte[] data)
    {
        return data[0];
    }
}