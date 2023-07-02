using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Core;

public class ConversionFailedException : Exception
{
    public ConversionFailedException(Type sourceType, Type targetType, string message) 
        : base($"Conversion from {sourceType} to {targetType} failed. {message}")
    {
    }
}
