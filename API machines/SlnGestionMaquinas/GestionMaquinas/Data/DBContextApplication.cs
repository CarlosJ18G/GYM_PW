using GestionMaquinas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionMaquinas.Data
{
    public class DBContextApplication: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("machines");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Status).HasColumnName("status");
            });

        }
        public DBContextApplication(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Machine> machines { get; set; } = null!;
    }
    
}

