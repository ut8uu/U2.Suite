using System;
using System.Runtime.Serialization;

namespace U2.Logger
{
    [Serializable]
    internal class BadLogInfoException : Exception
    {
        private const string ExceptionMessageFmt = "A log info file for log {0} not found.";

        public BadLogInfoException()
        {
        }

        public BadLogInfoException(string? logName) 
            : base(string.Format(ExceptionMessageFmt, logName))
        {
        }

        public BadLogInfoException(string? logName, Exception? innerException) 
            : base(string.Format(ExceptionMessageFmt, logName), innerException)
        {
        }

        protected BadLogInfoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}