using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Core.Exceptions
{
    public sealed class FileIOException : Exception
    {
        public FileIOException(string message) : base(message) { }
    }
}
