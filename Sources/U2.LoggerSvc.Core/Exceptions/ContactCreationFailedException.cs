using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.LoggerSvc.Core;

public sealed class ContactCreationFailedException : LoggerException
{
    public ContactCreationFailedException(string message) : base(message) { }
}
