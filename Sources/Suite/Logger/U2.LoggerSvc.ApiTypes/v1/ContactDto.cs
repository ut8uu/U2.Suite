using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace U2.LoggerSvc.ApiTypes.v1;

[Description("Represents a contact instance.")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class ContactDto
{
    [Description("A unique identifier of the contact.")]
    public Guid UniqueId { get; set; }

    [Description("A call of the remote station.")]
    public string? Call { get; set; } = "";

    [Description("The date and time of the QSO start. Usually, equals to DateTimeOff.")]
    public DateTime DateTimeOn { get; set; }

    [Description("The date and time of the QSO end. Usually, equals to tDateTimeOn.")]
    public DateTime DateTimeOff { get; set; }

    [Description("A name of the band of the QSO. Usually, equals to BandRx.")]
    public string? Band { get; set; }

    [Description("A name of the receiving band of the QSO. Usually, equals to BandRx.")]
    public string? BandRx { get; set; }

    [Description("A continent of the remote party. If set to 0, will be calculated from call.")]
    public int Continent { get; set; } = 0;

    [Description("A country of the remote party. If empty, will be calculated from call.")]
    public string? Country { get; set; } = "";

    [Description("A CQ zone of the remote party. If set to 0, will be calculated from call.")]
    public int Cqz { get; set; } = 0;

    [Description("A DXCC entity of the remote party. If set to 0, will be calculated from call.")]
    public int Dxcc { get; set; } = 0;

    [Description("A frequency of the QSO. Optional. If specified, must match the Band.")]
    public decimal Frequency { get; set; } = 0;

    [Description("A receiving frequency of the QSO. Optional. If specified, must match the BandRx.")]
    public decimal FrequencyRx { get; set; } = 0;

    [Description("A maidenhead grid square of the remote party. Optional.")]
    public string? Gridsquare { get; set; } = "";

    [Description("An Iota of the remote party. Optional.")]
    public string? Iota { get; set; } = "";

    [Description("A name of the island of the remote party. Optional.")]
    public string? IotaIslandId { get; set; } = "";

    [Description("The ITU zone of the remote party. Optional.")]
    public int Ituz { get; set; } = 0;

    [Description("A latitude of the remote party. Optional. Will be calculated from call if omitted.")]
    public decimal Lat { get; set; } = 0;

    [Description("A longitude of the remote party. Optional. Will be calculated from call if omitted.")]
    public decimal Lon { get; set; } = 0;

    [Description("A mode of the QSO. Required.")]
    public string? Mode { get; set; }

    [Description("A city of the operator. Optional.")]
    public string? MyCity { get; set; } = "";

    [Description("A country of the operator. Optional.")]
    public string? MyCountry { get; set; } = "";

    [Description("A CQ zone of the operator. Optional.")]
    public int MyCqZone { get; set; } = 0;

    [Description("A maidnhead grid square of the operator. Optional.")]
    public string? MyGridsquare { get; set; } = "";

    [Description("A ITU zone of the operator. Optional. Will be calculated from operator's call if omitted.")]
    public int MyItuZone { get; set; } = 0;

    [Description("A latitude of the operator. Optional. Will be calculated from operator's call if omitted.")]
    public decimal MyLat { get; set; } = 0;

    [Description("A longitude of the operator. Optional. Will be calculated from operator's call if omitted.")]
    public decimal MyLon { get; set; } = 0;

    [Description("A name of the operator. Optional.")]
    public string? MyName { get; set; } = "";

    [Description("A name of the operator at the remote party. Optional.")]
    public string? Name { get; set; } = "";

    [Description("A name of the operator. Optional.")]
    public string? Operator { get; set; } = "";

    [Description("A propagation used in the QSO. Optional.")]
    public string? Propagation { get; set; } = "";

    [Description("A sent report. Optional.")]
    public string? RstSent { get; set; } = "";

    [Description("A received report. Optional.")]
    public string? RstRcvd { get; set; } = "";

    [Description("A name of the satellite. Optional.")]
    public string? SatName { get; set; } = "";

    [Description("A mode used when working via satellite. Optional.")]
    public string? SatMode { get; set; } = "";

    [Description("An identifier of the QSO at QRZ.com. Optional.")]
    public string? QrzId { get; set; } = "";

    private string GetDebuggerDisplay() => $"{Call} @{Band} #{Mode}";
}
