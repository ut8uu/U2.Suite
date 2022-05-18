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

public sealed class ReceiverIdPacketChunk : UdpPacketChunk<ushort>
{
    public ReceiverIdPacketChunk(ushort receiverId)
        : base(PacketChunkType.ReceiverId,
            RigUdpMessengerPacket.ReceiverIdStart, RigUdpMessengerPacket.ReceiverIdLen,
            ByteFunctions.ReceiverIdToBytes(receiverId))
    {
    }

    public static ReceiverIdPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.ReceiverIdStart,
                RigUdpMessengerPacket.ReceiverIdLen);
        try
        {
            Array.Reverse(chunkData); // big endian is expected
            var value = BitConverter.ToUInt16(chunkData);
            return new ReceiverIdPacketChunk(value);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToReceiverIdError(chunkData));
        }
    }

    internal override byte[] GetBytesFromValue()
    {
        return ByteFunctions.ReceiverIdToBytes(Value);
    }

    internal override ushort GetValueFromBytes(byte[] data)
    {
        Debug.Assert(ChunkSize == 2);
        var chunkData = GetBytes(data, StartPosition, ChunkSize);
        try
        {
            return ByteFunctions.BytesToReceiverId(chunkData);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToReceiverIdError(chunkData));
        }
    }
}