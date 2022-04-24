namespace U2.MultiRig;

[Serializable]
public class FormatParseException : Exception
{
    public FormatParseException(string sourceString) :
        base($"Error parsing format from '{sourceString}'")
    {
            
    }
}