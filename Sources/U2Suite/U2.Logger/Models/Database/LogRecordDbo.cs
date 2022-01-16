using System;
using System.ComponentModel.DataAnnotations;

namespace U2.Logger
{
    public class LogRecordDbo
    {
        [Key]
        [StringLength(36)]
        public Guid RecordId { get; set; }
        [StringLength(50)]
        public string Callsign { get; set; } = default!;
        public DateTime DateTime { get; set; }
        public double Frequency { get; set; }
        [StringLength(8)]
        public string RstSent { get; set; } = default!;
        [StringLength(8)]
        public string RstReceived { get; set; } = default!;
        [StringLength(64)]
        public string Operator { get; set; } = default!;
        [StringLength(64)]
        public string Comments { get; set; } = default!;
    }
}