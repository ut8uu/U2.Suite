namespace U2.Suite.Brandmeister.Contracts;

public sealed class TalkGroupInfo
{
    public TalkGroupInfo() { }
    public TalkGroupInfo(int talkGroup, DateTime? lastSeen = null, int activityCount = 1)
    {
        TalkGroup = talkGroup;
        LastSeen = lastSeen ?? DateTime.UtcNow;
        ActivityCount = activityCount;
    }

    public int TalkGroup { get; set; }
    public DateTime LastSeen { get; set; }
    public int ActivityCount { get; set; }
}