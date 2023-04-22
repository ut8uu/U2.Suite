namespace U2.LoggerSvc.Core;

public sealed class ContactNotFoundException : LoggerException
{
    public ContactNotFoundException(int id, Exception? innerException = null) :
        base($"Contact with id='{id}' not found.", innerException)
    { }
}
