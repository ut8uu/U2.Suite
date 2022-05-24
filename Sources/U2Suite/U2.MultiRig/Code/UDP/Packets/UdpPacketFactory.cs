using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig;

public static class UdpPacketFactory
{
    private static byte _messageId = 0;
    private static byte GetNextMessageId()
    {
        return _messageId++;
    }

    public static RigUdpMessengerPacket CreateHeartbeatPacket(int rigNumber, ushort senderId)
    {
        var packet = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(),
            Timestamp = new TimestampPacketChunk(DateTime.UtcNow),
            MessageId = new MessageIdPacketChunk(GetNextMessageId()),
            SenderId = new SenderIdPacketChunk(senderId),
            ReceiverId = new ReceiverIdPacketChunk(KnownIdentifiers.MultiCast),
            MessageType = new MessageTypePacketChunk(MessageTypes.Status),
            Checksum = new ChecksumPacketChunk(0),
            CommandId = new CommandIdPacketChunk(CommandIdentifiers.SingleParameterChangedNotification),
            DataLength = new DataLengthPacketChunk(0),
            Data = new DataPacketChunk(Array.Empty<byte>()),
        };
        packet.Checksum.SetValue(packet.GetCheckSum());

        return packet;
    }

    public static RigUdpMessengerPacket CreateSingleParameterReportingPacket(int rigNumber,
        ushort senderId, ushort receiverId,
        RigParameter parameter, object? parameterValue)
    {
        if (parameterValue == null)
        {
            throw new ArgumentNullException(nameof(parameterValue));
        }

        var data = Array.Empty<byte>();
        if (parameterValue is string stringValue)
        {
            data = Encoding.UTF8.GetBytes(stringValue);
        }
        else if (parameterValue is int intValue)
        {
            data = BitConverter.GetBytes(intValue);
            Array.Reverse(data); // big endian
        }
        else if (parameterValue is ushort ushortValue)
        {
            data = ByteFunctions.CommandIdToBytes(ushortValue);
        }
        var packet = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(),
            Timestamp = new TimestampPacketChunk(DateTime.UtcNow),
            MessageId = new MessageIdPacketChunk(GetNextMessageId()),
            SenderId = new SenderIdPacketChunk(senderId),
            ReceiverId = new ReceiverIdPacketChunk(receiverId),
            MessageType = new MessageTypePacketChunk(MessageTypes.Status),
            Checksum = new ChecksumPacketChunk(0),
            CommandId = new CommandIdPacketChunk(CommandIdentifiers.SingleParameterChangedNotification),
            DataLength = new DataLengthPacketChunk((ushort)data.Length),
            Data = new DataPacketChunk(data),
        };
        packet.Checksum.SetValue(packet.GetCheckSum());

        return packet;
    }

    public static RigUdpMessengerPacket CreateMultipleParametersReportingPacket(int rigNumber,
        ushort senderId, ushort receiverId, IEnumerable<RigParameter> parameters)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        if (!parameters.Any())
        {
            throw new ArgumentException("A list of parameters is empty.", nameof(parameters));
        }

        var parametersValue = RigCommandUtilities.ParametersToUlong(parameters);
        var data = ByteFunctions.UlongToBytes(parametersValue);
        var packet = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(),
            Timestamp = new TimestampPacketChunk(DateTime.UtcNow),
            MessageId = new MessageIdPacketChunk(GetNextMessageId()),
            SenderId = new SenderIdPacketChunk(senderId),
            ReceiverId = new ReceiverIdPacketChunk(receiverId),
            MessageType = new MessageTypePacketChunk(MessageTypes.Status),
            Checksum = new ChecksumPacketChunk(0),
            CommandId = new CommandIdPacketChunk(CommandIdentifiers.SingleParameterChangedNotification),
            DataLength = new DataLengthPacketChunk((ushort)data.Length),
            Data = new DataPacketChunk(data),
        };
        packet.Checksum.SetValue(packet.GetCheckSum());

        return packet;
    }
}
