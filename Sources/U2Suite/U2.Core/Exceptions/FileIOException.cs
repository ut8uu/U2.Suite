using System;

namespace U2.Core.Exceptions
{
    public sealed class FileIOException : Exception
    {
        public FileIOException(string message) : base(message) { }
    }
}
