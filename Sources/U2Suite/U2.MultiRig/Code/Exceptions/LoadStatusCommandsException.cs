namespace U2.MultiRig;

[Serializable]
internal sealed class LoadStatusCommandsException : Exception
{
    public LoadStatusCommandsException(string message) : base(message)
    {
        
    }
}