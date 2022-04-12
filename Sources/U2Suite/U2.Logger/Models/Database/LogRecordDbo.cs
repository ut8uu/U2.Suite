using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace U2.Logger;

public class LogRecordDbo
{
    private string _hash = string.Empty;
    private string mode = string.Empty;
    private string callsign = string.Empty;
    private DateTime timestamp;
    private string band = string.Empty;

    public LogRecordDbo()
    {
        RecordId = Guid.NewGuid();
    }

    [Key]
    [StringLength(36)]
    public Guid RecordId { get; set; }
    [StringLength(50)]
    public string Callsign
    {
        get => callsign;
        set
        {
            callsign = value;
            ResetHash();
        }
    }
    public DateTime QsoBeginTimestamp { get; set; }
    public DateTime QsoEndTimestamp
    {
        get => timestamp;
        set
        {
            timestamp = value;
            ResetHash();
        }
    }
    public decimal Frequency { get; set; }
    [StringLength(8)]
    public string RstSent { get; set; } = string.Empty;
    [StringLength(8)]
    public string Mode
    {
        get => mode;
        set
        {
            mode = value;
            ResetHash();
        }
    }
    [StringLength(16)]
    public string Band
    {
        get => band;
        set
        {
            band = value;
            ResetHash();
        }
    }
    [StringLength(8)]
    public string RstReceived { get; set; } = string.Empty;
    [StringLength(64)]
    public string Operator { get; set; } = string.Empty;
    [StringLength(128)]
    public string Comments { get; set; } = string.Empty;

    [StringLength(256)]
    public string Hash
    {
        get => _hash;
    }

    public void ResetHash()
    {
        _hash = $"{Callsign}{QsoEndTimestamp}{Band}{Mode}";
    }
}
