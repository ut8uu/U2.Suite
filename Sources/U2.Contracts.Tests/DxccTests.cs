namespace U2.Contracts.Tests;

public class DxccTests
{
    [Fact]
    public void CanDeserializeDxccList()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var path = Path.Combine(currentDir, "DXCC", "dxcc.json");
        var dxccList = DxccList.FromFile(path);
        Assert.NotNull(dxccList);
        Assert.Equal(402, dxccList.Count);
    }
}