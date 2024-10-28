using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W5L2.Models;

namespace W5L2.Data
{
    public class W5L2Context : DbContext
    {
        public W5L2Context (DbContextOptions<W5L2Context> options)
            : base(options)
        {
        }

        public DbSet<W5L2.Models.UserA> UserA { get; set; } = default!;
        public DbSet<W5L2.Models.UserB> UserB { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserA>()
                .Property(u => u.FName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<UserA>()
                .Property(u => u.LName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<UserA>()
                .Property(u => u.Age)
                .IsRequired()
                .HasMaxLength(3);

            // Define a check constraint for Age
            modelBuilder.Entity<UserA>()
                .HasCheckConstraint("CK_UserA_Age", "[Age] >= 0 AND [Age] <= 200");

            modelBuilder.Entity<UserB>()
                .Property(ub => ub.title)
                .IsRequired();

            modelBuilder.Entity<UserB>()
                .Property(ub => ub.Biography)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<UserA>()
                .HasKey(u => u.ID); // Assuming ID is the primary key for UserA

            modelBuilder.Entity<UserB>()
                .HasKey(ub => ub.UserID); // Define UserID as the primary key for UserB

            modelBuilder.Entity<UserA>()
                .HasOne(u => u.UserB)
                .WithOne(ub => ub.UserA)
                .HasForeignKey<UserB>(ub => ub.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
