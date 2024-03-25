using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Suite.Helpers.Dxcc;

internal class DxccCacheEntry
{
    public DateTime Date { get; set; }
    public string Callsign { get; set; }
    public DxccEntry Entry { get; set; }
}
