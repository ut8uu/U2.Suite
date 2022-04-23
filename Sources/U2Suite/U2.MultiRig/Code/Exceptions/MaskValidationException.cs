namespace U2.MultiRig;

[Serializable]
internal sealed class MaskValidationException : Exception
{
    public MaskValidationException(string validationMessage) :
        base(validationMessage)
    {

    }
}