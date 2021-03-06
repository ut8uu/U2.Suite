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

namespace U2.MultiRig;

public sealed class MagicNumberPacketChunk : UdpPacketChunk<byte[]>
{
    private static readonly byte[] _signature = {0xAB, 0xBA, 0x11, 0x05};

    public MagicNumberPacketChunk()
        : base(PacketChunkType.MagicNumber,
            RigUdpMessengerPacket.MagicNumberStart, RigUdpMessengerPacket.MagicNumberLen, _signature)
    {
    }

    public MagicNumberPacketChunk(byte[] data) 
        : base(PacketChunkType.MagicNumber,
            RigUdpMessengerPacket.MagicNumberStart, RigUdpMessengerPacket.MagicNumberLen, 
            data)
    {
    }

    public static MagicNumberPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.MagicNumberStart,
                RigUdpMessengerPacket.MagicNumberLen);
        return new MagicNumberPacketChunk(chunkData);
    }

    internal override byte[] GetValueFromBytes(byte[] data)
    {
        return GetBytes(data, StartPosition, ChunkSize);
    }

    internal override byte[] GetBytesFromValue()
    {
        return Value ?? Array.Empty<byte>();
    }

    public override bool IsValid => (Value ?? Array.Empty<byte>()).SequenceEqual(_signature);
}