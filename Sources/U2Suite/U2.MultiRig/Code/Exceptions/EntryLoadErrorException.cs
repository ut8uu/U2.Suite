namespace U2.MultiRig;

[Serializable]
public sealed class EntryLoadErrorException : Exception
{
    public EntryLoadErrorException(string section, string entryName, string message = "")
        : base($"Error loading entry {entryName} from section {section}. {message}")
    {

    }
}