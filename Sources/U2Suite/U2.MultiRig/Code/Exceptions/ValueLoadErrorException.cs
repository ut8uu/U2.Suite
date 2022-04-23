namespace U2.MultiRig;

[Serializable]
internal sealed class ValueLoadErrorException : Exception
{
    public ValueLoadErrorException(string message) : base(message)
    {
        
    }
}