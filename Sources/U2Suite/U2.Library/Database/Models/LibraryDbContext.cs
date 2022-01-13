using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Library.Database.Rigs.Alinco;
using U2.Library.Database.Rigs.Wouxun;
using U2.Resources.Collections;

namespace U2.Library.Database.Models
{
    public sealed class LibraryDbContext : DbContext
    {
        private const string DataBaseName = "library.sq3";
        private readonly string _databasePath;

        public LibraryDbContext()
        {
            Vendors = default!;
            Rigs = default!;
            _databasePath = FileSystemHelper.GetFullPath(DataBaseName);
        }

        public DbSet<VendorDbo> Vendors { get; set; }
        public DbSet<RigDbo> Rigs { get; set; }

        private string GetConnectionString()
        {
            return $"Filename={_databasePath};";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vendors = EnumerateVendors();
            modelBuilder.Entity<VendorDbo>().HasData(vendors);
            modelBuilder.Entity<RigDbo>().HasData(EnumerateRigs(vendors));
        }

        private static IEnumerable<VendorDbo> EnumerateVendors()
        {
            return new List<VendorDbo>
            {
                new VendorDbo(VendorIds.AlincoId, VendorNames.Alinco),
                new VendorDbo(VendorIds.IcomId, VendorNames.Icom),
                new VendorDbo(VendorIds.KenwoodId, VendorNames.Kenwood),
                new VendorDbo(VendorIds.MotorolaId, VendorNames.Motorola),
                new VendorDbo(VendorIds.TenTecId, VendorNames.TenTec),
                new VendorDbo(VendorIds.WouxunId, VendorNames.Wouxun),
                new VendorDbo(VendorIds.YaesuId, VendorNames.Yaesu),
            };
        }

        private static IEnumerable<RigDbo> EnumerateRigs(IEnumerable<VendorDbo> vendors)
        {
            var list = new List<RigDbo>();
            
            list.AddRange(AlincoRadios.GetRadios());
            list.AddRange(WouxunRadios.GetRadios());

            for (var i = 0; i < list.Count; i++)
            {
                list[i].Id = i + 1;
            }

            return list;
        }
    }
}
