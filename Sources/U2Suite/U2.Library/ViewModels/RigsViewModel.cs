using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using U2.Library.Database.Models;

namespace U2.Library.ViewModels
{
    public sealed class RigsViewModel
    {
        private LibraryDbContext _dbContext;

        public RigsViewModel()
        {
            _dbContext = new LibraryDbContext();
            try
            {
                _dbContext.Database.Migrate();
            }
            catch { }

            Rigs = _dbContext.Rigs;
            Vendors = _dbContext.Vendors;
        }

        public IEnumerable<RigDbo> Rigs { get; set; }
        public int SelectedVendorIndex { get; set; } = 0;
        public IEnumerable<VendorDbo> Vendors { get; set; }
    }
}
