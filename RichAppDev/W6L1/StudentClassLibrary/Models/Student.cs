using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(16, 99, ErrorMessage = "Age must be between 16 and 99.")]
        public int Age { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "The Course field is Required")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public override string ToString()
        {
            return $"Student - Name: {Name}, ID: {Id}, Age: {Age}, Email: {Email}";
        }
    }
}
