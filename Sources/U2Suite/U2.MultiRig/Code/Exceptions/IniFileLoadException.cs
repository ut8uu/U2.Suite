namespace U2.MultiRig;

[Serializable]
public class IniFileLoadException : Exception
{
    public IniFileLoadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}