namespace U2.Suite.Brandmeister.Contracts;

public sealed class ReportDisplayData
{
    public string Call { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public int TG { get; set; }
    public TimeSpan Duration { get; set; }
    public double BER { get; set; }
    public int DXCC { get; set; }
    public string CountryName { get; set; } = string.Empty;

    public string CallString => $"{Call,-20}";
    public string DxccDisplayString => DXCC.ToString();
    public string TalkGroupString => TG.ToString();

    public void FromSessionData(SessionData data)
    {
        if (data == null)
        {
            return;
        }

        DateTimeOffset dateTimeStart = DateTimeOffset.FromUnixTimeSeconds(data.Start);
        DateTimeOffset dateTimeStop = DateTimeOffset.FromUnixTimeSeconds(data.Stop);
        DateTime dateTime = dateTimeStart.DateTime;
        var duration = dateTimeStop - dateTimeStart;
        if (duration.TotalSeconds < 0)
        {
            duration = TimeSpan.Zero;
        }

        Call = data.SourceCall!;
        CountryName = data.CountryName ?? "N/A";
        DateTime = dateTime;
        Duration = duration;
        BER = data.BER;
        TG = data.DestinationID;
        DXCC = data.Dxcc;
    }
}
