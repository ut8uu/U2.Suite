namespace U2.Suite.Brandmeister.Contracts;

public class IgnoredItem
{
    public IgnoredItem(object item, IgnoreType ignoreType)
    {
        Item = item;
        IgnoreType = ignoreType;
    }

    public object Item { get; }
    public IgnoreType IgnoreType { get; }
}
