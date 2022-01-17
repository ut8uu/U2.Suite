using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace U2.Logger.Models.Database
{
    public sealed class SettingsDbo
    {
        [Key]
        [StringLength(36)]
        public string SettingId { get; set; } = default!;

        [StringLength(36)] 
        public string Value { get; set; } = default!;
    }
}
