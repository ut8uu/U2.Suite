namespace U2.MultiRig;

internal class MaskParseException : Exception
{
    public MaskParseException(string sourceString) :
        base($"Error parsing mask from '{sourceString}'")
    {
        
    }
}