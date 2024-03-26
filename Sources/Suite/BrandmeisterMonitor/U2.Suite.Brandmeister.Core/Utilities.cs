using U2.Suite.Brandmeister.Contracts;

namespace U2.Suite.Brandmeister.Core;

public static class Utilities
{
    private static int GG<T>(FilterAndSortModel filter, IEnumerable<T> list, T value)
    {
        var newList = list.Append(value);
        var sortedList = filter.SortAscending ? newList.Order() : newList.OrderDescending();
        var sl = sortedList.ToList();
        return sl.IndexOf(value);
    }

    public static int FindNewIndex(FilterAndSortModel _filter, 
        List<ReportDisplayData> items, ReportDisplayData item)
    {
        return _filter.SortByIndex switch
        {
            BrandmeisterReportSortComparer.SortByCall => GG(_filter, items.Select(x => x.Call), item.Call),
            BrandmeisterReportSortComparer.SortByCountry => GG(_filter, items.Select(x => x.CountryName), item.CountryName),
            BrandmeisterReportSortComparer.SortByTalkGroup => GG(_filter, items.Select(x => x.TG), item.TG),
            BrandmeisterReportSortComparer.SortByTimestamp => GG(_filter, items.Select(x => x.DateTime), item.DateTime),
            _ => throw new ArgumentOutOfRangeException(nameof(_filter.SortByIndex)),
        };
    }

    public static bool IsItemIgnored(ReportDisplayData item,
    IEnumerable<IgnoredItem> ignoredItems,
    out IgnoreType[] ignoreTypes)
    {
        ignoreTypes = [];
        if (item == null)
        {
            return false;
        }

        var si = item;
        ignoreTypes = ignoredItems.Where(x => (x.IgnoreType == IgnoreType.Call && x.Item.ToString() == si.Call)
                || (x.IgnoreType == IgnoreType.Dxcc && (int)x.Item == si.DXCC)
                || (x.IgnoreType == IgnoreType.TalkGroup && (int)x.Item == si.TG)
                )
            .Select(x => x.IgnoreType).ToArray();
        return ignoreTypes.Any();
    }

}
