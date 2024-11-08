using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Lecturer Name")]
        public string LecturerName { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Course - Name: {Name}, ID: {Id}, Department: {DepartmentName}, " +
                $"Lecturer Name: {LecturerName}, No. of Students: {Students.Count.ToString()}");

            if (Students.Count > 0)
            {
                builder.AppendLine("Enrolled Students: ");
                foreach (var student in Students)
                {
                    builder.AppendLine($"- {student.Name} (ID: {student.Id})");
                }
            }
            else
            {
                builder.AppendLine("No students enrolled in this course.");
            }

            return builder.ToString();
        }
    }
}
