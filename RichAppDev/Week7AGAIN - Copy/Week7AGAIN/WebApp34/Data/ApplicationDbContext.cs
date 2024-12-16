using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection.Emit;
using WebApp34.Data.Models;

namespace WebApp34.Data
{
    public class ApplicationDbContext
    : IdentityDbContext<
        ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {

        public DbSet<WebApp34.Data.Models.Contact> Contact { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("notdbo");

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("MyUsers");

                // Properties
                b.Property(u => u.UserName).HasMaxLength(128);
                b.Property(u => u.NormalizedUserName).HasMaxLength(128);
                b.Property(u => u.Email).HasMaxLength(128);
                b.Property(u => u.NormalizedEmail).HasMaxLength(128);

                // Relationships
                b.HasMany(u => u.Claims)
                    .WithOne(uc => uc.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(u => u.Logins)
                    .WithOne(ul => ul.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(u => u.Tokens)
                    .WithOne(ut => ut.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(u => u.UserRoles)
                    .WithOne(ur => ur.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("MyRoles");

                // Relationships
                b.HasMany(r => r.UserRoles)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(r => r.RoleClaims)
                    .WithOne(rc => rc.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationUserClaim>(b =>
            {
                b.ToTable("MyUserClaims");
            });

            modelBuilder.Entity<ApplicationUserLogin>(b =>
            {
                b.ToTable("MyUserLogins");
            });

            modelBuilder.Entity<ApplicationUserToken>(b =>
            {
                b.ToTable("MyUserTokens");

                b.Property(t => t.LoginProvider).HasMaxLength(128);
                b.Property(t => t.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<ApplicationUserRole>(b =>
            {
                b.ToTable("MyUserRoles");
            });

            modelBuilder.Entity<ApplicationRoleClaim>(b =>
            {
                b.ToTable("MyRoleClaims");
            });

            modelBuilder.Entity<ApplicationResult>(b =>
            {
                b.ToTable($"{nameof(ApplicationResult)}.Result");
            });
        }

    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("YourConnectionStringHere");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
