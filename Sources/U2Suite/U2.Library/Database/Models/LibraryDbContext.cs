using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using U2.Core;

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

            var vendors = EnumerateVendors();
            modelBuilder.Entity<VendorDbo>().HasData(vendors);
            modelBuilder.Entity<RigDbo>().HasData(EnumerateRigs(vendors));
        }

        private static string RigsDirectory
        {
            get
            {
                var currentDirectory = Path.GetDirectoryName(typeof(LibraryDbContext).Assembly.Location);
                Debug.Assert(!string.IsNullOrEmpty(currentDirectory));
                return Path.Combine(currentDirectory, "Database", "Rigs");
            }
        }

        private static List<VendorDbo> EnumerateVendors()
        {
            var result = new List<VendorDbo>();
            var index = 1;
            foreach (var directory in Directory.EnumerateDirectories(RigsDirectory))
            {
                result.Add(new VendorDbo(index++, Path.GetFileName(directory)));
            }

            return result;
        }

        private static List<RigDbo> EnumerateRigs(IEnumerable<VendorDbo> vendors)
        {
            var list = new List<RigDbo>();

            var rigsDirectory = RigsDirectory;

            var index = 1;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            foreach (var vendor in vendors)
            {
                var vendorPath = Path.Combine(rigsDirectory, vendor.Name);
                foreach (var jsonFile in Directory.EnumerateFiles(vendorPath, "*.json"))
                {
                    var json = File.ReadAllText(jsonFile);
                    var rigInfos = JsonSerializer.Deserialize<List<RigInfo>>(json, options);
                    foreach (var rigInfo in rigInfos)
                    {
                        Debug.Assert(!string.IsNullOrEmpty(rigInfo.Name));
                        var rig = new RigDbo
                        {
                            Id = index++,
                            Image = rigInfo.Image,
                            Name = rigInfo.Name,
                            VendorId = vendor.Id,
                            PowerWatts = rigInfo.Power ?? string.Empty,
                            WeightGrams = rigInfo.Weight ?? string.Empty,
                            Dimensions = rigInfo.Dimensions ?? string.Empty,
                        };
                        list.Add(rig);
                    }
                }
            }

            return list;
        }
    }
}
