using DynamicData;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public class RigSettings
{
    public RigSettings()
    {
        BaudRate = Data.BaudRates.IndexOf(9600);
        DataBits = Data.DataBits.IndexOf(8);
        StopBits = Data.StopBits.IndexOf(1m);
    }

    public string RigId { get; set; } = string.Empty;
    public int RigType { get; set; } = -1;
    public int Port { get; set; } = -1;
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public int Parity { get; set; } = 0;
    public int StopBits { get; set; }
    public int RtsMode { get; set; } = 0;
    public int DtrMode { get; set; } = 0;
    public int PollMs { get; set; } = 500;
    public int TimeoutMs { get; set; } = 3000;
}
