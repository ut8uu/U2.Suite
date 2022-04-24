namespace U2.MultiRig;

[Serializable]
internal sealed class LoadInitCommandsException : Exception
{
    public LoadInitCommandsException(string message, Exception innerException) 
        : base(message, innerException)
    {
        
    }
    public LoadInitCommandsException(string message) : base(message)
    {
        
    }
}