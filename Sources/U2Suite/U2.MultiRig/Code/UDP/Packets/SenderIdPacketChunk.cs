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
using U2.MultiRig.Code.Exceptions;

namespace U2.MultiRig;

public sealed class SenderIdPacketChunk : UdpPacketChunk<ushort>
{
    public SenderIdPacketChunk(ushort senderId)
        : base(PacketChunkType.SenderId,
            RigUdpMessengerPacket.SenderIdStart, RigUdpMessengerPacket.SenderIdLen,
            ByteFunctions.SenderIdToBytes(senderId))
    {
    }

    public static SenderIdPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.SenderIdStart,
            RigUdpMessengerPacket.SenderIdLen);
        try
        {
            var value = ByteFunctions.BytesToSenderId(chunkData);
            return new SenderIdPacketChunk(value);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToSenderIdError(chunkData));
        }
    }

    internal override byte[] GetBytesFromValue()
    {
        return ByteFunctions.SenderIdToBytes(Value);
    }

    internal override ushort GetValueFromBytes(byte[] data)
    {
        Debug.Assert(ChunkSize == 2);
        try
        {
            return ByteFunctions.BytesToSenderId(data);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToSenderIdError(data));
        }
    }
}