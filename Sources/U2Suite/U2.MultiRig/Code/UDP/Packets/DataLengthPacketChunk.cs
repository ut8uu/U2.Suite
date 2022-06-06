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
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public sealed class DataLengthPacketChunk : UdpPacketChunk<ushort>
{
    public DataLengthPacketChunk(ushort data)
        : base(PacketChunkType.DataLength,
            RigUdpMessengerPacket.DataLengthStart, 
            RigUdpMessengerPacket.DataLengthLen,
            ByteFunctions.DataLengthToBytes(data))
    {
    }

    public static DataLengthPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.DataLengthStart,
            RigUdpMessengerPacket.DataLengthLen);
        try
        {
            Array.Reverse(chunkData); // big endian is expected
            var value = BitConverter.ToUInt16(chunkData);
            return new DataLengthPacketChunk(value);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToDataLengthError(chunkData));
        }
    }

    internal override byte[] GetBytesFromValue()
    {
        var data = BitConverter.GetBytes(Value);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    internal override ushort GetValueFromBytes(byte[] data)
    {
        Debug.Assert(data.Length == 2);
        try
        {
            return ByteFunctions.BytesToDataLength(data);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToDataLengthError(data));
        }
    }
}