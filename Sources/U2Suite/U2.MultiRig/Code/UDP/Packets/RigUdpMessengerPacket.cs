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

namespace U2.MultiRig.Code.UDP;

public sealed class RigUdpMessengerPacket
{
    public const int MagicNumberStart = 0;
    public const int MagicNumberLen = 4;
    public const int TimestampStart = MagicNumberStart + MagicNumberLen;
    public const int TimestampLen = 8;

    public MagicNumberPacketChunk? MagicNumber { get; init; }
    public TimestampPacketChunk? Timestamp { get; init; }

    public static RigUdpMessengerPacket Create(byte[] data)
    {
        var result = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(data),
            Timestamp = new TimestampPacketChunk(data),
        };

        return result;
    }
}