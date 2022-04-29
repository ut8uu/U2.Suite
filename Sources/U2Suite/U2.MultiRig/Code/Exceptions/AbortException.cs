namespace U2.MultiRig;

[Serializable]
public class AbortException : Exception
{
    public AbortException(){}
    public AbortException(string message) : base(message){}
}