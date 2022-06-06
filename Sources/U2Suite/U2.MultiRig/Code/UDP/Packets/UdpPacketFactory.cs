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
        RigParameter parameter, object parameterValue)
    {
        if (parameterValue == null)
        {
            throw new ArgumentNullException(nameof(parameterValue));
        }

        var data = new List<byte>(ByteFunctions.RigParameterToBytes(parameter));
        if (parameterValue is string stringValue)
        {
            data.AddRange(Encoding.UTF8.GetBytes(stringValue));
        }
        else if (parameterValue is int intValue)
        {
            data.AddRange(ByteFunctions.IntToBytes(intValue));
        }
        else if (parameterValue is ushort ushortValue)
        {
            data.AddRange(ByteFunctions.UshortToBytes(ushortValue));
        }
        else if (parameterValue is ulong uLongValue)
        {
            data.AddRange(ByteFunctions.UlongToBytes(uLongValue));
        }

        var dataArray = data.ToArray();
        
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
            DataLength = new DataLengthPacketChunk((ushort)dataArray.Length),
            Data = new DataPacketChunk(dataArray),
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

    /// <summary>
    /// Creates packet containing a request for setting the parameter.
    /// </summary>
    /// <param name="rigNumber"></param>
    /// <param name="senderId"></param>
    /// <param name="receiverId"></param>
    /// <param name="rigParameter"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static RigUdpMessengerPacket CreateSetRigParameterPacket(
        int rigNumber, ushort senderId, ushort receiverId, 
        RigParameter rigParameter, long value)
    {
        var bytes = new List<byte>();
        bytes.Add(16); // data length = 2x(int64)
        bytes.AddRange(ByteFunctions.LongToBytes((long)rigParameter));
        bytes.AddRange(ByteFunctions.LongToBytes(value));
        var data = bytes.ToArray();
        var dataChunk = new DataPacketChunk(data);

        var packet = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(),
            Timestamp = new TimestampPacketChunk(DateTime.UtcNow),
            MessageId = new MessageIdPacketChunk(GetNextMessageId()),
            SenderId = new SenderIdPacketChunk(senderId),
            ReceiverId = new ReceiverIdPacketChunk(receiverId),
            MessageType = new MessageTypePacketChunk(MessageTypes.Status),
            Checksum = new ChecksumPacketChunk(0),
            CommandId = new CommandIdPacketChunk(CommandIdentifiers.SingleParameterChangeRequest),
            DataLength = new DataLengthPacketChunk((ushort)data.Length),
            Data = dataChunk,
        };
        packet.Checksum.SetValue(packet.GetCheckSum());

        return packet;
    }
}
