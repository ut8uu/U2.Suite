namespace U2.MultiRig;

[Serializable]
public sealed class ParameterParseException : Exception
{
    public ParameterParseException(string message) :
        base($"Error parsing parameter from '{message}'")
    {

    }
}