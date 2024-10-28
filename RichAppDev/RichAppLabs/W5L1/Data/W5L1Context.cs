using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W5L1.Models;

namespace W5L1.Data
{
    public class W5L1Context : DbContext
    {
        public W5L1Context (DbContextOptions<W5L1Context> options)
            : base(options)
        {
        }

        public DbSet<W5L1.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.title)
                .HasConversion(
                    v => v.ToString(),
                    v => (Title)Enum.Parse(typeof(Title), v)
                );
        }
            /*public DbSet<W5L1.Models.UserA> UserA { get; set; } = default!;
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UserA>()
                    .Property(u => u.title)
                    .HasConversion(
                        v => v.ToString(),
                        v => (Title)Enum.Parse(typeof(Title), v)
                    );
                modelBuilder.Entity<UserA>()
                    .Property(u => u.FName)
                    .IsRequired()
                    .HasMaxLength(20);
                modelBuilder.Entity<UserA>()
                    .Property(u => u.LName)
                    .IsRequired()
                    .HasMaxLength(20);
                modelBuilder.Entity<UserA>()
                    .Property(u => u.Biography)
                    .IsRequired()
                    .HasMaxLength(200);
                modelBuilder.Entity<UserA>()
                    .Property(u => u.Age)
                    .HasMaxLength(3);
                modelBuilder.Entity<UserA>()
                    .HasCheckConstraint("CK_UserA_Age", "[Age] <= 200");

            }*/

        }
}
