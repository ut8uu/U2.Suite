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

namespace U2.MultiRig;

public sealed class ChecksumPacketChunk : UdpPacketChunk<byte>
{
    public ChecksumPacketChunk(byte data)
        : base(PacketChunkType.Checksum,
            RigUdpMessengerPacket.ChecksumStart, RigUdpMessengerPacket.ChecksumLen,
            new[] { data })
    {
    }

    public static ChecksumPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.ChecksumStart,
                RigUdpMessengerPacket.ChecksumLen);
        return new ChecksumPacketChunk(chunkData[0]);
    }

    internal override byte[] GetBytesFromValue()
    {
        return new[] { Value };
    }

    internal override byte GetValueFromBytes(byte[] data)
    {
        Debug.Assert(data.Length == 1);
        return data.First();
    }
}