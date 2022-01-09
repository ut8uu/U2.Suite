using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Resources.Collections;

namespace U2.Library.Database.Models
{
    public sealed class LibraryDbContext : DbContext
    {
        private const string DataBaseName = "library.sq3";
        private readonly string _databasePath;

        public LibraryDbContext()
        {
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

            modelBuilder.Entity<VendorDbo>().HasData(EnumerateVendors());
            modelBuilder.Entity<RigDbo>().HasData(EnumerateRigs());
        }

        private IEnumerable<VendorDbo> EnumerateVendors()
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

        private IEnumerable<RigDbo> EnumerateRigs()
        {
            return new List<RigDbo>
            {

            };
        }
    }
}
