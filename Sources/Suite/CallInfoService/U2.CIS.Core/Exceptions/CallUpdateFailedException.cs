namespace U2.CIS.Core;

/// <summary>
/// Represents an exception during the updating of a call to the database.
/// </summary>
public class CallUpdateFailedException : CisException
{
	public CallUpdateFailedException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
