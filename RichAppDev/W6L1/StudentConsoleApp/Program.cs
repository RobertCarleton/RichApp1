using System;
using StudentClassLibrary.Models;
using StudentConsoleApp.Data;

namespace YourConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ConsoleDbContext())
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Example: Adding a new student
                var student = new Student { Name = "Alice", Age = 20, Email = "Alice123@gmail.com", Id = 1 };
                context.Students.Add(student);
                //context.SaveChanges();

                // Example: Adding a course and associating a student
                var course = new Course { Name = "Introduction to Programming", DepartmentName = "Computing",
                    LecturerName = "John Wick", Id = 1};
                course.Students = new List<Student> { student };
                context.Courses.Add(course);
                //context.SaveChanges();

                Console.WriteLine("Student and course added successfully!");
                var courses = context.Courses.ToList();
                var students = context.Students.ToList();
                foreach(var c in courses)
                    Console.WriteLine(c.ToString());
                foreach (var s in students)
                    Console.WriteLine(s.ToString());
            }
        }
    }
}
