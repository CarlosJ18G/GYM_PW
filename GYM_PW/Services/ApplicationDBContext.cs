using Microsoft.EntityFrameworkCore; //dotnet add package Microsoft.EntityFrameworkCore
using GYM_PW.Models.User;
using GYM_PW.Models.Geography;
using GYM_PW.Models.Business;

public class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.Id).HasColumnName("id"); 
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Countries>(entity =>
        {
            entity.ToTable("countries");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Active).HasColumnName("active");
        });
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Countries> Countries { get; set; }

public DbSet<GYM_PW.Models.Business.Machine> Machine { get; set; } = default!;
}
