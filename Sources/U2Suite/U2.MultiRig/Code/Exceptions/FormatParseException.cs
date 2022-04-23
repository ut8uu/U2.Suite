namespace U2.MultiRig;

internal class FormatParseException : Exception
{
    public FormatParseException(string sourceString) :
        base($"Error parsing format from '{sourceString}'")
    {
            
    }
}