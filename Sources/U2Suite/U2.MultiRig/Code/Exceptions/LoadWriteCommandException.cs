namespace U2.MultiRig;

[Serializable]
public sealed class LoadWriteCommandException : Exception
{
    public LoadWriteCommandException(string message) 
        : base(message)
    {
        
    }

    public LoadWriteCommandException(string message, Exception innerException) 
        : base(message, innerException)
    {
        
    }
}