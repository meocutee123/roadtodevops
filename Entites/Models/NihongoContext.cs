using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Nihongo.Entites.Models
{
    public partial class NihongoContext : DbContext
    {
        public NihongoContext()
        {
        }

        public NihongoContext(DbContextOptions<NihongoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Landlord> Landlords { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NTUANNGHIA\\SQLEXPRESS;Database=Nihongo;Trusted_Connection=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
