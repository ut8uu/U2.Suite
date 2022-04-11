using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace U2.Logger;

public class LogRecordDbo
{
    private string _hash;

    public LogRecordDbo()
    {
        RecordId = Guid.NewGuid();
    }

    [Key]
    [StringLength(36)]
    public Guid RecordId { get; set; }
    [StringLength(50)]
    public string Callsign { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public decimal Frequency { get; set; }
    [StringLength(8)]
    public string RstSent { get; set; } = default!;
    [StringLength(8)]
    public string Mode { get; set; } = default!;
    [StringLength(16)]
    public string Band { get; set; } = default!;
    [StringLength(8)]
    public string RstReceived { get; set; } = default!;
    [StringLength(64)]
    public string Operator { get; set; } = default!;
    [StringLength(128)]
    public string Comments { get; set; } = default!;

    public string Hash
    {
        get
        {
            if (_hash == null)
            {
                _hash = $"{Callsign}{Timestamp}{Band}{Mode}";
            }
            return _hash;
        }
    } 
}
