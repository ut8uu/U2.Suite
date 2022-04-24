namespace U2.MultiRig;

[Serializable]
public sealed class MaskValidationException : Exception
{
    public MaskValidationException(string message) :
        base(message)
    {

    }
}