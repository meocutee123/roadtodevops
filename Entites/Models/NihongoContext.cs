using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Property>()
            .HasOne(s => s.CreatedByAccount)
            .WithMany(g => g.PropertiesCreatedBy)
            .HasForeignKey(s => s.CreatedBy);

            modelBuilder.Entity<Property>()
            .HasOne(s => s.ModifiedByAccount)
            .WithMany(g => g.PropertiesModifiedBy)
            .HasForeignKey(s => s.LastModifiedBy);

            modelBuilder.Entity<Building>()
            .HasOne(s => s.CreatedByAccount)
            .WithMany(g => g.BuildingsCreatedBy)
            .HasForeignKey(s => s.CreatedBy);

            modelBuilder.Entity<Building>()
            .HasOne(s => s.ModifiedByAccount)
            .WithMany(g => g.BuildingsModifiedBy)
            .HasForeignKey(s => s.LastModifiedBy);

            modelBuilder.Entity<Landlord>()
            .HasOne(s => s.CreatedByAccount)
            .WithMany(g => g.LandlordsCreatedBy)
            .HasForeignKey(s => s.CreatedBy);

            modelBuilder.Entity<Landlord>()
            .HasOne(s => s.ModifiedByAccount)
            .WithMany(g => g.LandlordsModifiedBy)
            .HasForeignKey(s => s.LastModifiedBy);
        }
    }
}
