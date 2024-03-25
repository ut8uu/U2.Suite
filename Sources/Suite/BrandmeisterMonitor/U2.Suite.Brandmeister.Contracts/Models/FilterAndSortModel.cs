namespace U2.Suite.Brandmeister.Contracts;

public sealed class FilterAndSortModel
{
    public string TextFilter { get; set; } = "";
    public FilterVisibilityOption VisibilityOption { get; set; }
    public bool SortAscending { get; set; }
    public int SortByIndex { get; set; }
    public string[] SortByItems { get; set; } = [];
}
