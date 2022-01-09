﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace U2.Library.Database.Models
{
    public class RigDbo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public int VendorId { get; set; }

        public int? ManufactureStart { get; set; }
        public int? ManufactureEnd { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Depth { get; set; }
        public int? WeightGrams { get; set; }
        public int? PowerWatts { get; set; }
        [StringLength(150)]
        public string DataDirectory { get; set; }

        [InverseProperty("Rigs")]
        public virtual VendorDbo Vendor { get; set; }
    }
}
