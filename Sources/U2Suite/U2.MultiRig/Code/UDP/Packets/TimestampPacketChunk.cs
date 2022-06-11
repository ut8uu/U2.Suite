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

namespace U2.MultiRig;

public sealed class TimestampPacketChunk : UdpPacketChunk<DateTime>
{
    public TimestampPacketChunk(DateTime timestamp)
        : base(PacketChunkType.Timestamp,
            RigUdpMessengerPacket.TimestampStart, RigUdpMessengerPacket.TimestampLen,
            ByteFunctions.TimestampToBytes(timestamp))
    {
    }

    public static TimestampPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.TimestampStart,
                RigUdpMessengerPacket.TimestampLen);
        try
        {
            var timestamp = ByteFunctions.BytesToTimestamp(chunkData);
            return new TimestampPacketChunk(timestamp);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToTimestampError(chunkData));
        }
    }

    internal override byte[] GetBytesFromValue()
    {
        return ByteFunctions.TimestampToBytes(Value);
    }

    internal override DateTime GetValueFromBytes(byte[] data)
    {
        try
        {
            return ByteFunctions.BytesToTimestamp(data);
        }
        catch (ArgumentException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToTimestampError(data));
        }
    }
}