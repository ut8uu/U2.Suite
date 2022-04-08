using System;
using System.Runtime.Serialization;

namespace U2.Logger
{
    [Serializable]
    internal class FileWriteException : Exception
    {
        public FileWriteException()
        {
        }

        public FileWriteException(string? message) : base(message)
        {
        }

        public FileWriteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FileWriteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}