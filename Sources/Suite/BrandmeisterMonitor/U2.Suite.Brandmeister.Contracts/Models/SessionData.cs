namespace U2.Suite.Brandmeister.Contracts;

public sealed class SessionData
{
    public string? LinkName { get; set; }
    public string? SessionID { get; set; }
    public int? LinkType { get; set; }
    public int? ContextID { get; set; }
    public int SessionType { get; set; }
    public int Slot { get; set; }
    public int SourceID { get; set; }
    public int DestinationID { get; set; }
    public string? Route { get; set; }
    public string? LinkCall { get; set; }
    public string? SourceCall { get; set; }
    public string? SourceName { get; set; }
    public string? DestinationCall { get; set; }
    public string? DestinationName { get; set; }
    public object? State { get; set; }
    public long Start { get; set; }
    public int Stop { get; set; }
    public string? RSSI { get; set; }
    public double BER { get; set; }
    public int ReflectorID { get; set; }
    public string? LinkTypeName { get; set; }
    public List<string>? CallTypes { get; set; }
    public int LossCount { get; set; }
    public int TotalCount { get; set; }
    public string? Master { get; set; }
    public string? TalkerAlias { get; set; }
    public int FlagSet { get; set; }
    public string? Event { get; set; }

    // calculated automatically
    public int Dxcc { get; set; }
    public string? CountryName { get; set; }
}
