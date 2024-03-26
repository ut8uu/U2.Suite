namespace U2.Suite.Brandmeister.Contracts;

internal sealed class BrandmeisterMonitorPreferences
{
    public bool Verbose { get; internal set; }
    public List<string>? NoisyCalls { get; internal set; }
}