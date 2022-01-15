using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U2.Library.Database.Models
{
    public class RigDbo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = default!;

        public int VendorId { get; set; }

        [StringLength(80)]
        public string Dimensions { get; set; } = default!;
        [StringLength(100)]
        public string RigType { get; set; } = default!;
        [StringLength(50)]
        public string WeightGrams { get; set; } = default!;
        [StringLength(80)]
        public string PowerWatts { get; set; } = default!;
        [StringLength(150)]
        public string Image { get; set; } = default!;

        [InverseProperty("Rigs")]
        public virtual VendorDbo Vendor { get; set; } = default!;
    }
}
