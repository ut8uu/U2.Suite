using System.Text;
using Newtonsoft.Json;
using U2.Core;

namespace U2.Contracts.Tests;

public class DxccTests
{
    DxccParser parser;

    public DxccTests() 
    {
        var path = Path.Combine(FileSystemHelper.GetLocalFolder(), "TestData", "DXCC", "cty.dat");
        parser = new DxccParser(path);
    }

    [Theory]
    [InlineData("KG4AA", "Guantanamo Bay")]
    [InlineData("KG4AAA", "United States")]
    [InlineData("W8LR/R", "United States")] // (Rover)
    [InlineData("K1KW/M", "United States")]
    [InlineData("K1KW/A", "United States")]
    [InlineData("K1KW/P", "United States")]
    [InlineData("N6TR/7", "United States")]
    [InlineData("N6TR/QRP", "United States")]
    [InlineData("KH0CW", "United States")] // (if everything is not ok, this was Mariana Island)
    [InlineData("K1KW/AM", "None")] // -- Aeronautical Mobile")]
    [InlineData("K1KW/MM", "None")] // -- Maritime Mobile")]
    [InlineData("KZ1H/PP", "Brazil")] // (not used, but to distinguish between /P and /PP)")]
    [InlineData("3D2RA", "Rotuma Island")]
    [InlineData("VE3EY/VP9", "Bermuda")]
    [InlineData("VP2MDG", "Montserrat")]
    [InlineData("VP2EY", "Anguilla")]
    [InlineData("VP2VI", "British Virgin Islands")]
    [InlineData("VP2V/AA7V", "British Virgin Islands")]
    [InlineData("SO1FH", "Poland")]
    [InlineData("TF/DL2NWK/P", "Iceland")]
    [InlineData("OZ1ALS/A", "Denmark")]
    [InlineData("LA1K", "Norway")]
    [InlineData("TF/DL2NWK/M", "Iceland")]
    [InlineData("TF/DL2NWK/MM", "None")]
    [InlineData("2M0SQL/P", "Scotland")] // (portable)")]
    [InlineData("FT8WW", "Crozet Island")]
    [InlineData("OH/DJ1YFK", "Finland")]
    [InlineData("RV1AL", "European Russia")]
    [InlineData("RV0AL/1", "European Russia")]
    [InlineData("RV1AL/0/P", "Asiatic Russia")]
    [InlineData("RV0AL/0/P", "Asiatic Russia")]
    public void CanCalculateDxcc(string call, string expectedCountryName)
    {
        var dxcc = parser.CallTester(call);
        Assert.NotNull(dxcc);
        if (expectedCountryName == "None")
        {
            Assert.Empty(dxcc);
        }
        else
        {
            Assert.Equal(expectedCountryName, dxcc[0]);
        }
    }

    [Fact]
    public void CanUseDxccHelper()
    {
        var dxcc = DxccHelper.CalculateFromCall("ut8uu");
        Assert.NotNull(dxcc);
        Assert.Equal("UR", dxcc.CountryCode);
    }
}