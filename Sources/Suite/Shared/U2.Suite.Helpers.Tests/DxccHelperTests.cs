using System.Globalization;

namespace U2.Suite.Helpers.Tests;

public class DxccHelperTests
{
    [Theory]
    [InlineData("3D2A", "176", "")]
    [InlineData("3D2C", "489", "")]
    [InlineData("3D2ER", "176", "")] // 1994/08/01-1994/08/31=489
    [InlineData("3D2ER", "489", "1994/08/01")] // 1994/08/01-1994/08/31=489
    [InlineData("FK8AA", "162", "")]
    //[InlineData("FK8CA", "512", "")] ????
    [InlineData("KH8SK", "515", "")]
    [InlineData("KH8YI", "9", "")]
    [InlineData("ON9AX", "209", "")]
    [InlineData("PU4AAP", "108", "")]
    [InlineData("RA3PX", "54", "")]
    [InlineData("UT8UU", "288", "")]
    public void CanConvertCallToDxccEntry(string call, string dxcc, string dateString)
    {
        var format = "yyyy/MM/dd";
        if (string.IsNullOrEmpty(dateString)) { 
            dateString = DateTime.UtcNow.Date.ToString(format); 
        }
        Assert.True(DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out DateTime date));
        var result = DxccHelper.Call2Dxcc(call, date);
        Assert.Equal(dxcc, result.Adif);
    }
}