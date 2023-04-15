using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.LoggerSvc.Core;

public class ConversionFailedException : LoggerException
{
    public ConversionFailedException(Type sourceType, Type targetType, string message) 
        : base($"Conversion from {sourceType} to {targetType} failed. {message}")
    {
    }
}
