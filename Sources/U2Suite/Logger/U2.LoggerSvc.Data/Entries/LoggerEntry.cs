using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.LoggerSvc.Data;

#nullable disable

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class LoggerEntry
{
    public int Id { get; set; }
    public Guid UniqueId { get; set; } = Guid.NewGuid();

    public string Call { get; set; } = "";

    public DateTime DateTimeOn { get; set; }
    public DateTime DateTimeOff { get; set; }
    public string Band { get; set; } = "";
    public string BandRx { get; set; } = "";
    public int Continent { get; set; } = 0;
    public string Country { get; set; } = "";
    public int Cqz { get; set; } = 0;
    public bool Dirty { get; set; } = false;
    public int Dxcc { get; set; } = 0;
    public decimal Frequency { get; set; }
    public decimal FrequencyRx { get; set; }
    public string Gridsquare { get; set; } = "";
    public string Iota { get; set; } = "";
    public string IotaIslandId { get; set; } = "";
    public bool IsRunQso { get; set; } = false;
    public int Ituz { get; set; } = 0;
    public decimal Lat { get; set; }
    public decimal Lon { get; set; }
    public string Mode { get; set; } = "";
    public string MyCity { get; set; } = "";
    public string MyCountry { get; set; } = "";
    public int MyCqZone { get; set; }
    public string MyGridsquare { get; set; } = "";
    public int MyItuZone { get; set; }
    public decimal MyLat { get; set; }
    public decimal MyLon { get; set; }
    public string MyName { get; set; } = "";
    public string Name { get; set; } = "";
    public string Operator { get; set; } = "";
    public string Propagation { get; set; } = "";
    public string RstSent { get; set; } = "";
    public string RstRcvd { get; set; } = "";
    public string SatName { get; set; } = "";
    public string SatMode { get; set; } = "";
    public string Timestamp { get; set; } = "";
    public string QrzId { get; set; } = "";

    private string GetDebuggerDisplay() => $"{Call} @{Band} #{Mode}";

}
