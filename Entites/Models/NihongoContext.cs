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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NTUANNGHIA\\SQLEXPRESS;Database=Nihongo;Trusted_Connection=true;");
            }
        }
    }
}
