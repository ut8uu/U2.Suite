namespace U2.MultiRig;

[Serializable]
internal sealed class ValueValidationException : Exception
{
    public ValueValidationException(string message) : base(message)
    {
        
    }
}