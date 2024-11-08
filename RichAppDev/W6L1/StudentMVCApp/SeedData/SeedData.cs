using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentMVCApp.Data;
using StudentClassLibrary.Models;
using System;
using System.Linq;

namespace StudentMVCApp
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SMVCDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SMVCDbContext>>()))
            {
                // Check if any students or courses already exist
                if (context.Students.Any() || context.Courses.Any())
                {
                    return; // Database has been seeded
                }

                // Add sample courses and save to ensure IDs are generated
                var course1 = new Course
                {
                    Name = "Introduction to Programming",
                    DepartmentName = "Computer Science",
                    LecturerName = "Dr. Smith"
                };
                var course2 = new Course
                {
                    Name = "Data Structures",
                    DepartmentName = "Computer Science",
                    LecturerName = "Dr. Jones"
                };

                context.Courses.AddRange(course1, course2);
                context.SaveChanges(); // Save courses to generate Course IDs

                // Add sample students with valid CourseId references
                context.Students.AddRange(
                    new Student
                    {
                        Name = "Alice Johnson",
                        Age = 20,
                        Email = "alice.johnson@example.com",
                        CourseId = course1.Id  // Reference existing CourseId
                    },
                    new Student
                    {
                        Name = "Bob Smith",
                        Age = 22,
                        Email = "bob.smith@example.com",
                        CourseId = course1.Id  // Reference existing CourseId
                    },
                    new Student
                    {
                        Name = "Charlie Brown",
                        Age = 19,
                        Email = "charlie.brown@example.com",
                        CourseId = course2.Id  // Reference existing CourseId
                    }
                );

                // Save changes to the database
                context.SaveChanges();
            }
        }
    }
}
