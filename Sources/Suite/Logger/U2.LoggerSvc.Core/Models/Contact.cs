using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Contracts;

namespace U2.LoggerSvc.Core;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class Contact
{
    public Guid UniqueId { get; set; } = Guid.NewGuid();
    public string Call { get; set; } = "";
    public DateTime DateTimeOn { get; set; }
    public DateTime DateTimeOff { get; set; }
    public RadioBand Band { get; set; }
    public RadioBand BandRx { get; set; }
    public Continent Continent { get; set; } = 0;
    public string Country { get; set; } = "";
    public int Cqz { get; set; } = 0;
    public int Dxcc { get; set; } = 0;
    public decimal Frequency { get; set; } = 0;
    public decimal FrequencyRx { get; set; } = 0;
    public string Gridsquare { get; set; } = "";
    public string Iota { get; set; } = "";
    public string IotaIslandId { get; set; } = "";
    public bool IsRunQso { get; set; } = false;
    public int Ituz { get; set; } = 0;
    public decimal Lat { get; set; } = 0;
    public decimal Lon { get; set; } = 0;
    public RadioMode Mode { get; set; }
    public string MyCity { get; set; } = "";
    public string MyCountry { get; set; } = "";
    public int MyCqZone { get; set; } = 0;
    public string MyGridsquare { get; set; } = "";
    public int MyItuZone { get; set; } = 0;
    public decimal MyLat { get; set; } = 0;
    public decimal MyLon { get; set; } = 0;
    public string MyName { get; set; } = "";
    public string Name { get; set; } = "";
    public string Operator { get; set; } = "";
    public string Propagation { get; set; } = "";
    public string RstSent { get; set; } = "";
    public string RstRcvd { get; set; } = "";
    public string SatName { get; set; } = "";
    public string SatMode { get; set; } = "";
    public string QrzId { get; set; } = "";

    private string GetDebuggerDisplay() => $"{Call} @{Band} #{Mode}";
}
