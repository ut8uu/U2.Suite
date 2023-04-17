using System.Collections.Generic;
using Newtonsoft.Json;

namespace U2.Contracts;

public class Dxcc
{
    [JsonProperty("continent")]
    public string[] Continent { get; set; }

    [JsonProperty("countryCode")]
    public string CountryCode { get; set; }

    [JsonProperty("cq")]
    public int[] Cq { get; set; }

    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("entityCode")]
    public int EntityCode { get; set; }

    [JsonProperty("flag")]
    public string Flag { get; set; }

    [JsonProperty("itu")]
    public int[] Itu { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [JsonProperty("outgoingQslService")]
    public bool OutgoingQslService { get; set; }

    [JsonProperty("prefix")]
    public string Prefix { get; set; }

    [JsonProperty("prefixRegex")]
    public string PrefixRegex { get; set; }

    [JsonProperty("thirdPartyTraffic")]
    public bool ThirdPartyTraffic { get; set; }

    [JsonProperty("validEnd")]
    public string ValidEnd { get; set; }

    [JsonProperty("validStart")]
    public string ValidStart { get; set; }

    public static Dxcc None { 
        get {
            return new Dxcc
            {
                Name = "None",
                EntityCode = 0,
            };
        } 
    }
}
