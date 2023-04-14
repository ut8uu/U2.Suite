using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U2.Logger.Data;

[PrimaryKey(nameof(Id))]
public sealed class LogEntry
{
    public Guid Id { get; set; }
    public Guid UniqueId { get; set; }

    public string Call { get; set; }

    public DateTime DateTimeOn { get; set; }
    public DateTime DateTimeOff { get; set; }
    public string Band { get; set; }
    public string BandRx { get; set; }
    public string Continent { get; set; }
    public string Country { get; set; }
    public string Cqz { get; set; }
    public string Dirty { get; set; }
    public string Dxcc { get; set; }
    public string Frequency { get; set; }
    public string FrequencyRx { get; set; }
    public string Gridsquare { get; set; }
    public string Iota { get; set; }
    public string IotaIslandId { get; set; }
    public string IsRunQso { get; set; }
    public string Ituz { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }
    public string Mode { get; set; }
    public string MyCity { get; set; }
    public string MyCountry { get; set; }
    public string MyCqZone { get; set; }
    public string MyGridsquare { get; set; }
    public string MyItuZone { get; set; }
    public string MyLat { get; set; }
    public string MyLon { get; set; }
    public string MyName { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public string Propagation { get; set; }
    public string RstSent { get; set; }
    public string RstRcvd { get; set; }
    public string SatName { get; set; }
    public string SatMode { get; set; }
    public string Timestamp { get; set; }
    public string QrzId { get; set; }
}
