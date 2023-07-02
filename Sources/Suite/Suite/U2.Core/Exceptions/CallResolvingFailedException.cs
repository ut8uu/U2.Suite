using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Core;

public class CallResolvingFailedException : Exception
{
    public CallResolvingFailedException(string call) : base($"Resolving of call '{call}' failed.") { }
}
