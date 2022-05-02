namespace U2.MultiRig.Utils;

public sealed class ConsoleManagementElement
{
    public ConsoleKey Key { get; init; }
    public string? Title { get; init; }
    public Func<object[], bool>? Function { get; init; }
    public object[] FunctionParameters { get; init; }
}