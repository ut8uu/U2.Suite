using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Suite.Brandmeister.Contracts;

namespace U2.Suite.Brandmeister.Core.Tests;

public class UtilitiesTests
{
    List<ReportDisplayData> GetTestReports() => [
        new ReportDisplayData()
        {
            Call = "BB1BB",
            TG = 9,
            Duration = TimeSpan.FromSeconds(10),
            DateTime = DateTime.Now,
            DXCC = 10,
            CountryName = "ddd",
        },
        new ReportDisplayData()
        {
            Call = "XX1XX",
            TG = 92,
            Duration = TimeSpan.FromSeconds(11),
            DateTime = DateTime.Now.AddMinutes(10),
            DXCC = 30,
            CountryName = "xxx",
        },
        new ReportDisplayData()
        {
            Call = "DD1DD",
            TG = 2,
            Duration = TimeSpan.FromSeconds(5),
            DateTime = DateTime.Now.AddMinutes(20),
            DXCC = 20,
            CountryName = "bbb",
        },
    ];

    [Theory]
    [InlineData("AA1AA", 50, 0, true, BrandmeisterReportSortComparer.SortByCall, 0, "", 0)]
    [InlineData("CC1CC", 50, 0, true, BrandmeisterReportSortComparer.SortByCall, 0, "", 1)]
    [InlineData("AA1AA", 50, 0, true, BrandmeisterReportSortComparer.SortByTalkGroup, 0, "", 2)]
    [InlineData("CC1CC", 5000, 0, true, BrandmeisterReportSortComparer.SortByTalkGroup, 0, "", 3)]
    [InlineData("CC1CC", 5000, 5, true, BrandmeisterReportSortComparer.SortByTimestamp, 0, "", 1)]
    [InlineData("CC1CC", 5, 5, true, BrandmeisterReportSortComparer.SortByCountry, 11, "ccc", 1)]
    [InlineData("CC1CC", 5, 5, false, BrandmeisterReportSortComparer.SortByCountry, 11, "ccc", 2)]
    public void IndexFinder(string call, int tg, int addMinutes,
        bool sortAscending, int sortByIndex,
        int dxcc, string countryName
        , int expectedIndex)
    {
        var testData = GetTestReports();
        var filter = new FilterAndSortModel
        {
            SortAscending = sortAscending,
            SortByIndex = sortByIndex,
        };

        var item = new ReportDisplayData
        {
            Call = call,
            TG = tg,
            Duration = TimeSpan.FromSeconds(5),
            DateTime = DateTime.Now.AddMinutes(addMinutes),
            CountryName = countryName,
            DXCC = dxcc,
        };

        var actualIndex = Utilities.FindNewIndex(filter, testData, item);
        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData("AA1AA", IgnoreType.Call, true)]
    [InlineData(5, IgnoreType.TalkGroup, true)]
    [InlineData(10, IgnoreType.Dxcc, true)]
    [InlineData(1, IgnoreType.TalkGroup, false)]
    public void CanWorkWithIgnoredItems(object item, IgnoreType type, bool expectedResult)
    {
        var displayData = new ReportDisplayData
        {
            Call = "AA1AA",
            TG = 5,
            Duration = TimeSpan.FromSeconds(5),
            DateTime = DateTime.Now,
            DXCC = 10,
        };
        var ignoredItems = new List<IgnoredItem>
        {
            new IgnoredItem(item, type),
        };
        var result = Utilities.IsItemIgnored(displayData, ignoredItems, out var ignoreTypes);
        Assert.Equal(expectedResult, result);
    }
}
