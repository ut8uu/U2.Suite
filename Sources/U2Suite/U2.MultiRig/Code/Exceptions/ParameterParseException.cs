namespace U2.MultiRig;

[Serializable]
internal sealed class ParameterParseException : Exception
{
    public ParameterParseException(string sourceString) :
        base($"Error parsing parameter from '{sourceString}'")
    {

    }
}