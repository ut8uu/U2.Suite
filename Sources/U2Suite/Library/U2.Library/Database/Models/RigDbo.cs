/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
