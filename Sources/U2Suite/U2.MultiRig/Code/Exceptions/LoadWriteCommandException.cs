namespace U2.MultiRig;

[Serializable]
internal sealed class LoadWriteCommandException : Exception
{
    public LoadWriteCommandException(string message) : base(message)
    {
        
    }
}