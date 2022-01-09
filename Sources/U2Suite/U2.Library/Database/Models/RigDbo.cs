using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace U2.Library.Database.Models
{
    public class RigDbo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? VendorId { get; set; }

        [InverseProperty("Rigs")]
        public virtual VendorDbo Vendor { get; set; }
    }
}
