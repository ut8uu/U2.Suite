using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.LoggerSvc.Core;

public abstract class LoggerException : Exception
{
    public LoggerException(string? message, Exception? innerException = null) 
        : base(message, innerException)
    {
    }
}
