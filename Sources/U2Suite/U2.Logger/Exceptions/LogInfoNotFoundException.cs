using System;
using System.Runtime.Serialization;

namespace U2.Logger
{
    [Serializable]
    public class LogInfoNotFoundException : Exception
    {
        public LogInfoNotFoundException()
        {
        }

        public LogInfoNotFoundException(string? logName) 
            : base($"A log info file for log {logName} not found.")
        {
        }

        public LogInfoNotFoundException(string? logName, Exception? innerException) 
            : base($"A log info file for log {logName} not found.", innerException)
        {
        }

        protected LogInfoNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}