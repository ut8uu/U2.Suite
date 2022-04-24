namespace U2.MultiRig;

[Serializable]
public sealed class ValueLoadErrorException : Exception
{
    public ValueLoadErrorException(string message) : base(message)
    {
        
    }
}