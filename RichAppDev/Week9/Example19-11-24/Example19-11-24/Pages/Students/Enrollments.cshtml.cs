using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Pages.Students
{
    public class EnrollmentsModel : PageModel
    {
        private readonly CollegeContext _context;

        public EnrollmentsModel(CollegeContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }

        // Fetch students and their enrolled courses
        public void OnGet()
        {
            Students = _context.Students
                .Include(s => s.Courses) // Include related courses
                .Where(s => s.Courses.Any())
                .ToList();
        }

        // Handle unenrollment action
        public IActionResult OnPostUnenroll(int studentId, int courseId)
        {
            // Find the student
            var student = _context.Students
                .Include(s => s.Courses) // Include courses for the student
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Find the course
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            // Remove the course from the student's list of courses
            student.Courses.Remove(course);

            // Optionally remove the student from the course's list of students
            course.Students.Remove(student);

            // Save the changes to the database
            _context.SaveChanges();

            // Refresh the page
            return RedirectToPage();
        }
    }
}
