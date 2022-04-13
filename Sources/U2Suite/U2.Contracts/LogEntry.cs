using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Contracts
{
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
        public LogEntryType Type { get; set; } = LogEntryType.Info;
        public string Message { get; set; } = default!;
    }
}
