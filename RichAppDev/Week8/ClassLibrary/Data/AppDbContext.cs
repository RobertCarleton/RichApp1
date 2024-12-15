using ClassLibrary;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ClassLibrary;Trusted_Connection=True;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vet>()
            .HasMany(v => v.Pets)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

