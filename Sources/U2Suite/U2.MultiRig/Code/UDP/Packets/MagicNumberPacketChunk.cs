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

using U2.MultiRig.Code.Exceptions;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public sealed class MagicNumberPacketChunk : UdpPacketChunk<string?>
{
    private readonly byte[] _signature = new byte[] {0xAB, 0xBA, 0x11, 0x05};

    public MagicNumberPacketChunk(byte[] data) 
        : base("MagicNumber", PacketChunkType.MagicNumber,
            RigUdpMessengerPacket.MagicNumberStart, RigUdpMessengerPacket.MagicNumberLen, 
            data)
    {
    }

    internal override string? GetValueFromBytes(byte[] data)
    {
        var chunkData = GetBytes(data, StartPosition, ChunkSize);
        var hexValue = ByteFunctions.BytesToHex(chunkData);
        if (!chunkData.SequenceEqual(_signature))
        {
            throw new UdpPacketException(KnownErrors.FormatWrongSignatureError(hexValue));
        }

        return hexValue;
    }

    internal override byte[] GetBytesFromValue()
    {
        return ByteFunctions.HexStrToBytes(Value ?? string.Empty);
    }
}