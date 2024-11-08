using Microsoft.EntityFrameworkCore;
using StudentClassLibrary.Models;

namespace StudentMVCApp.Data
{
    public class SMVCDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SMVCDbContext(DbContextOptions<SMVCDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if options are not already set (e.g., by dependency injection)
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=C:\\Users\\Robert C\\Documents\\GitHub\\RichApp1\\RichAppDev\\W6L1\\StudentMVCApp\\students.db";
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                // One-To-Many Model with Course
                entity.HasOne(s => s.Course)
                      .WithMany(c => c.Students)
                      .HasForeignKey(s => s.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(s => s.Email)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(s => s.Age)
                      .IsRequired();

                entity.Property(s => s.CourseId)
                      .IsRequired();
            });

            // Configure Course entity properties only (relationship already defined)
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.DepartmentName)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(c => c.LecturerName)
                      .IsRequired()
                      .HasMaxLength(30);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
