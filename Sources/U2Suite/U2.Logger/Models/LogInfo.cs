using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Logger;

public sealed class LogInfo
{
    public string? LogName { get; set; }
    public string? Description { get; set; }

    public string? StationCallsign { get; set; }
    public string? OperatorCallsign { get; set; }
    public string? ActivatedReference { get; set; }

    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public int NumberOfRecords { get; set; }
}
