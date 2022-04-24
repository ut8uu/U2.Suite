namespace U2.MultiRig;

[Serializable]
public sealed class LoadStatusCommandsException : Exception
{
    public LoadStatusCommandsException(string message, Exception innerException) 
        : base(message, innerException)
    {
        
    }
    public LoadStatusCommandsException(string message) : base(message)
    {
        
    }
}