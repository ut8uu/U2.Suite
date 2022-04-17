namespace U2.MultiRig;

public class RigSettings
{
    public RigSettings()
    {
    }

    public string RigId { get; set; } = string.Empty;
    public int RigType { get; set; }
    public int Port { get; set; }
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public int Parity { get; set; }
    public int StopBits { get; set; }
    public int RtsMode { get; set; }
    public int DtrMode { get; set; }
    public int PollMs { get; set; }
    public int TimeoutMs { get; set; }
}
