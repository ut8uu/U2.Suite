namespace U2.MultiRig;

[Serializable]
public class MaskParseException : Exception
{
    public MaskParseException(string sourceString) :
        base($"Error parsing mask from '{sourceString}'")
    {
        
    }
}