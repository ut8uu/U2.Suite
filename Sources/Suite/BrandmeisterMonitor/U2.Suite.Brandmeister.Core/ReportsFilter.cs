using U2.Suite.Brandmeister.Core.Models;
using U2.Suite.Helpers;

namespace U2.Suite.Brandmeister.Core;

internal enum FilterCriteria
{
    Equals = 0,
    IsNotEqual = 1,
    StartsWith = 2,
    EndsWith = 3,
    Contains = 4,
    DoesNotContain = 5,
}

internal enum FilterTarget
{
    Call,
    TalkGroup,
    Dxcc,
}

internal static class ReportsFilter
{
    private static List<ReportsFilterItem>? _items = null;
    private static string _path = Path.Combine(FileSystemHelper.BrandmeisterStorageDataFolder, "ReportsFilter.json");

    public static List<string> AllSearchCriteriaOptions { get; } =
        [
            "Equals",
            "Is not equal",
            "Starts with",
            "Ends with",
            "Contains",
            "Does not contain",
        ];

    public static List<string> AllFilterTargetOptions { get; } =
        [
            "Callsign",
            "Talk Group",
            "DXCC",
        ];

    public static List<ReportsFilterItem> Items
    {
        get
        {
            if (_items == null)
            {
                Load();
            }
            return _items!;
        }
    }

    private static void Load()
    {
        _items = FileSystemHelper.ReadFromFile<List<ReportsFilterItem>>(_path);
        if (_items == null)
        {
            _items = [];
        }
    }

    public static void Save()
    {
        FileSystemHelper.EnsureDirectory(FileSystemHelper.BrandmeisterStorageDataFolder);
        FileSystemHelper.SaveToFile(_path, Items);
    }

    public static void Add(ReportsFilterItem item)
    {
        Items.Add(item);
        Save();
    }

    public static bool IsFiltered(string value, FilterTarget target)
    {
        foreach (var item in Items.Where(x => x.Target == target)) 
        {
            switch (item.Criteria)
            {
                case FilterCriteria.Equals:
                    if (value.Equals(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
                case FilterCriteria.IsNotEqual:
                    if (!value.Equals(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
                case FilterCriteria.StartsWith:
                    if (value.StartsWith(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
                case FilterCriteria.EndsWith:
                    if (value.EndsWith(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
                case FilterCriteria.Contains:
                    if (value.Contains(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
                case FilterCriteria.DoesNotContain:
                    if (!value.Contains(item.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    break;
            }
        }

        return false;
    }
}
