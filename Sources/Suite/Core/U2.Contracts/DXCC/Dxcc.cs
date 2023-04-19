using System.Collections.Generic;
using Newtonsoft.Json;

namespace U2.Contracts;

public class Dxcc
{
    public string Continent { get; set; }

    public string CountryCode { get; set; }

    public int CqZone { get; set; }

    public int ItuZone { get; set; }

    public string Name { get; set; }

    public string Prefix { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal TimeZoneOffset { get; set; }

    public static Dxcc None { 
        get {
            return new Dxcc
            {
                Name = "None",
                CountryCode = "None",
            };
        } 
    }
}
