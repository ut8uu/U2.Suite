namespace U2.LoggerSvc.Core;

public sealed class ContactUpdateFailedException : LoggerException
{
    public ContactUpdateFailedException(int id, Exception? innerException = null) :
        base($"Updating of the contact with id='{id}' failed.", innerException)
    { }
}
