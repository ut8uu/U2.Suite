using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.CIS.Core;

/// <summary>
/// Represents an exception during the addition of a call to the database.
/// </summary>
public class CallAddFailedException: CisException
{
	public CallAddFailedException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
