using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace U2.Library.Database.Models
{
    public class VendorDbo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Vendor")]
        public virtual ICollection<RigDbo> Rigs { get; set; }

        public VendorDbo() { }
        public VendorDbo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
