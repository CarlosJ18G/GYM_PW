using Microsoft.EntityFrameworkCore; //dotnet add package Microsoft.EntityFrameworkCore
using GYM_PW.Models.User;

public class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.Id).HasColumnName("id"); // Añade esto
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Password).HasColumnName("password");
        });
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}
