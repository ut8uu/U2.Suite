namespace U2.CIS.Core;

public class CisException : Exception
{
	public CisException(string? message, Exception? innerException) 
		: base(message, innerException)
	{
	}
}