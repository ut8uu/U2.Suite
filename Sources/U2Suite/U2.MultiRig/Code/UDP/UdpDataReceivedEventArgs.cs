using System.Net;

namespace U2.MultiRig;

#nullable disable
public class UdpDataReceivedEventArgs
{
    public byte[] Data { get; set; }

    public EndPoint EndPoint { get; set; }
}