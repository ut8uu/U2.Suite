namespace U2.LoggerSvc.Core;

public sealed class ContactRemovingFailedException : LoggerException
{
    public ContactRemovingFailedException(int id, Exception? innerException = null) :
        base($"Removing of the contact with id='{id}' failed.", innerException)
    { }
}
