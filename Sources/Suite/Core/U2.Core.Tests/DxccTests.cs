using U2.Core.Helpers;

namespace U2.Contracts.Tests;

public class DxccTests
{
    [Fact]
    public void CanDeserializeDxccList()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var path = Path.Combine(currentDir, "DXCC", "dxcc.json");
        var dxccList = DxccHelper.FromFile(path);
        Assert.NotNull(dxccList);
        Assert.Equal(402, dxccList.Count);
    }
}