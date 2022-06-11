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

public static class CommandIdentifiers
{
    public const ushort Information = 0;
    public const ushort Heartbeat = 1;
    public const ushort MultipleParametersChangedNotification = 0x10;
    public const ushort MultipleParametersChangeRequest = 0x11;
    public const ushort SingleParameterChangedNotification = 0x20;
    public const ushort SingleParameterChangeRequest = 0x21;
}

public sealed class CommandIdPacketChunk : UdpPacketChunk<ushort>
{
    public CommandIdPacketChunk(ushort commandId)
        : base(PacketChunkType.CommandId,
            RigUdpMessengerPacket.CommandIdStart, RigUdpMessengerPacket.CommandIdLen,
            ByteFunctions.CommandIdToBytes(commandId))
    {
    }

    public static CommandIdPacketChunk FromUdpPacket(byte[] data)
    {
        var chunkData = GetBytes(data, RigUdpMessengerPacket.CommandIdStart,
                RigUdpMessengerPacket.CommandIdLen);
        try
        {
            Array.Reverse(chunkData); // big endian is expected
            var value = BitConverter.ToUInt16(chunkData);
            return new CommandIdPacketChunk(value);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToCommandIdError(chunkData));
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
        try
        {
            return ByteFunctions.BytesToCommandId(data);
        }
        catch (ArgumentException)
        {
            throw new UdpPacketException(KnownErrors.FormatByteToCommandIdError(data));
        }
    }
}