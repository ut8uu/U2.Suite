using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Suite.Helpers;

public sealed class DxccEntry
{
    public string Pattern { get; set; }
    public string Details { get; set; }
    public string Continent { get; set; }
    public string Utc { get; set; }
    public string Lat { get; set; }
    public string Lng { get; set; }
    public string Itu { get; set; }
    public string Waz { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string Adif { get; set; }
}

public sealed class DxccEntries : List<DxccEntry>
{

    public DxccEntries() { }
    public DxccEntries(IEnumerable<DxccEntry> collection) : base(collection)
    {
        this.AddRange(collection);
    }
}
