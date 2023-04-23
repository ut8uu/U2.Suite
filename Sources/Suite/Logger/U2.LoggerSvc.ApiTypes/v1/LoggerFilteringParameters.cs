namespace U2.LoggerSvc.ApiTypes;

public class LoggerFilteringParameters
{
    public string[] Calls { get; set; } = Array.Empty<string>();

    public string[] Modes { get; set; } = Array.Empty<string>();
    public string[] Bands { get; set; } = Array.Empty<string>();
}