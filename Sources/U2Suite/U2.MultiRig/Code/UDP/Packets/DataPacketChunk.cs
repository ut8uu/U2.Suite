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
using U2.MultiRig.Code.Exceptions;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public sealed class DataPacketChunk : UdpPacketChunk<byte[]>
{
    public DataPacketChunk(byte[] data) 
        : base(PacketChunkType.Data, RigUdpMessengerPacket.DataStart, 65536, data)
    {
    }

    public static DataPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.DataStart, 65536);
        return new DataPacketChunk(chunkData);
    }

    internal override byte[] GetBytesFromValue()
    {
        return Value ?? Array.Empty<byte>();
    }

    internal override byte[] GetValueFromBytes(byte[] data)
    {
        return data ?? Array.Empty<byte>();
    }

    public static DataPacketChunk Create(byte[] data)
    {
        var result = new DataPacketChunk(Array.Empty<byte>());
        result.SetValue(data);
        return result;
    }
}