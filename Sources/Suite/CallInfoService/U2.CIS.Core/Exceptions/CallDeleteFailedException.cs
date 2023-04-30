namespace U2.CIS.Core;

/// <summary>
/// Represents an exception raised during the deletion of the call from the database.
/// </summary>
public class CallDeleteFailedException : CisException
{
	public CallDeleteFailedException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
