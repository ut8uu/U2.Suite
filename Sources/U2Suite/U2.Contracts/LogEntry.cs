using System;

namespace U2.Contracts;

public enum LogEntryType
{
    Info,
    Warning,
    Error,
}

public sealed class LogEntry
{
    public LogEntry(LogEntryType type, string message)
    {
        Type = type;
        Message = message;
        TimeStamp = DateTime.UtcNow;
    }

    public DateTime TimeStamp { get; set; }
    public LogEntryType Type { get; set; }
    public string Message { get; set; }
}
