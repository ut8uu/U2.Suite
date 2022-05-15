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
    public const int MessageIdStart = TimestampStart + TimestampLen;
    public const int MessageIdLen = 2;
    public const int SenderIdStart = MessageIdStart + MessageIdLen;
    public const int SenderIdLen = 2;
    public const int ReceiverIdStart = SenderIdStart + SenderIdLen;
    public const int ReceiverIdLen = 2;
    public const int MessageTypeStart = ReceiverIdStart + ReceiverIdLen;
    public const int MessageTypeLen = 1;
    public const int ChecksumStart = MessageTypeStart + MessageTypeLen;
    public const int ChecksumLen = 4;
    public const int CommandIdStart = ChecksumStart + ChecksumLen;
    public const int CommandIdLen = 2;
    public const int DataLengthStart = CommandIdStart + CommandIdLen;
    public const int DataLengthLen = 2;
    public const int DataStart = DataLengthStart + DataLengthLen;

    public MagicNumberPacketChunk? MagicNumber { get; init; }
    public TimestampPacketChunk? Timestamp { get; init; }
    public MessageIdPacketChunk? MessageId { get; init; }
    public SenderIdPacketChunk? SenderId { get; set; }
    public ReceiverIdPacketChunk? ReceiverId { get; set; }
    public MessageTypePacketChunk? MessageType { get; set; }
    public ChecksumPacketChunk? Checksum { get; set; }
    public CommandIdPacketChunk? CommandId { get; set; }
    public DataLengthPacketChunk? DataLength { get; set; }
    public DataPacketChunk? Data { get; set; }

    public static RigUdpMessengerPacket Create(byte[] data)
    {
        var result = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(data),
            Timestamp = new TimestampPacketChunk(data),
            MessageId = new MessageIdPacketChunk(data),
            SenderId = new SenderIdPacketChunk(data),
            ReceiverId = new ReceiverIdPacketChunk(data),
            MessageType = new MessageTypePacketChunk(data),
            Checksum = new ChecksumPacketChunk(data),
            CommandId = new CommandIdPacketChunk(data),
            DataLength = new DataLengthPacketChunk(data),
            Data = new DataPacketChunk(data),
        };

        return result;
    }
}