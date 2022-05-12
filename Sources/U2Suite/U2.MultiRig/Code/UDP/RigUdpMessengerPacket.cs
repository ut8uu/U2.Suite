namespace U2.MultiRig.Code.UDP;

public sealed class RigUdpMessengerPacket
{
    public MagicNumberPacketChunk? MagicNumber { get; set; }

    public static RigUdpMessengerPacket Create(byte[] data)
    {
        var result = new RigUdpMessengerPacket
        {
            MagicNumber = new MagicNumberPacketChunk(data)
        };

        return result;
    }
}