using Serilog;
using U2.Suite.Brandmeister.Contracts;

namespace U2.Suite.Brandmeister.Core;

public class BrandmeisterReportSortComparer : IComparer<object>
{
    public const int SortByCall = 0;
    public const int SortByCountry = 1;
    public const int SortByTalkGroup = 2;
    public const int SortByTimestamp = 3;

    public static FilterAndSortModel SortModel = new()
    {
        SortAscending = true,
        SortByIndex = 0,
    };

    public int Compare(object? x, object? y)
    {
        try
        {
            var result = 0;

            if (x is ReportDisplayData xx && y is ReportDisplayData yy)
            {
                switch (SortModel.SortByIndex)
                {
                    case SortByCall:
                        // sort by Call
                        result = string.Compare(xx.Call, yy.Call, ignoreCase: true);
                        break;
                    case SortByCountry:
                        // sort by Country
                        result = string.Compare(xx.CountryName, yy.CountryName, ignoreCase: true);
                        break;
                    case SortByTalkGroup:
                        // sort by TG
                        if (xx.TG < yy.TG)
                        {
                            result = -1;
                        }
                        else if (xx.TG > yy.TG)
                        {
                            result = 1;
                        }
                        break;
                    case SortByTimestamp:
                        // sort by timestamp
                        if (xx.DateTime < yy.DateTime)
                        {
                            result = -1;
                        }
                        else if (xx.DateTime > yy.DateTime)
                        {
                            result = 1;
                        }
                        break;
                }
            }

            if (!SortModel.SortAscending)
            {
                result = -result;
            }

            return result;
        }
        catch (Exception ex)
        {
            Log.Logger.Fatal(ex, "CallInfoSortComparer");
        }
        return 0;
    }
}
