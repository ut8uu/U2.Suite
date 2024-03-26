namespace U2.Suite.Brandmeister.Contracts;

public class CallInfo
{
    public CallInfo() { }

    public CallInfo(string call, DateTime timestamp, int activityCount = 1)
    {
        Call = call;
        LastSeen = timestamp;
        ActivityCount = activityCount;
    }

    public string? StatusImagePath { get; set; }
    public string Call { get; set; } = string.Empty;
    public bool IsIgnored { get; set; }
    public DateTime LastSeen { get; set; }
    public int ActivityCount { get; set; }
}
