using System;

namespace U2.Core.Exceptions
{
    public sealed class FileIOException : Exception
    {
        public FileIOException(string message) : base(message) { }

        public FileIOException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
