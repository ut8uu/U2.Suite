namespace U2.MultiRig;

[Serializable]
public sealed class ValueValidationException : Exception
{
    public ValueValidationException(string message) : base(message)
    {
        
    }
}