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

        public virtual DbSet<Kanji> Kanjis { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NTUANNGHIA\\SQLEXPRESS;Database=Nihongo;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Kanji>(entity =>
            {
                entity.ToTable("Kanji");

                entity.Property(e => e.English)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Japanese)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KanaSpelling).HasMaxLength(50);

                entity.Property(e => e.Romanization).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
