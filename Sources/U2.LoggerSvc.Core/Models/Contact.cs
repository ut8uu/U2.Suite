using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Contracts;

namespace U2.LoggerSvc.Core;

#nullable disable

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class Contact
{
    public Guid Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Call { get; set; }
    public DateTime DateTimeOn { get; set; }
    public DateTime DateTimeOff { get; set; }
    public RadioBand? Band { get; set; }
    public RadioBand? BandRx { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }
    public string Cqz { get; set; }
    public string Dxcc { get; set; }
    public decimal? Frequency { get; set; }
    public decimal? FrequencyRx { get; set; }
    public string Gridsquare { get; set; }
    public string Iota { get; set; }
    public string IotaIslandId { get; set; }
    public string IsRunQso { get; set; }
    public string Ituz { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public RadioMode Mode { get; set; }
    public string MyCity { get; set; }
    public string MyCountry { get; set; }
    public string MyCqZone { get; set; }
    public string MyGridsquare { get; set; }
    public string MyItuZone { get; set; }
    public decimal? MyLat { get; set; }
    public decimal? MyLon { get; set; }
    public string MyName { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public string Propagation { get; set; }
    public string RstSent { get; set; }
    public string RstRcvd { get; set; }
    public string SatName { get; set; }
    public string SatMode { get; set; }
    public string QrzId { get; set; }

    private string GetDebuggerDisplay() => $"{Call} @{Band} #{Mode}";
}
