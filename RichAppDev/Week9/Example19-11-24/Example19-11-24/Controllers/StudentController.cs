using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Controllers
{
    public class StudentController : Controller
    {
        private readonly CollegeContext _context;

        public StudentController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Students/NotEnrolled
        [HttpGet]
        [Route("Shared/NotEnrolled")]
        public async Task<IActionResult> NotEnrolled()
        {
            var students = await _context.Students
                .Where(s => !s.Courses.Any())
                .ToListAsync();

            return View(students);
        }

        public async Task<IActionResult> Enrollments()
        {
            var students = await _context.Students
                .Include(s => s.Courses)
                .ToListAsync();

            return View(students);
        }

        // POST: Unenroll a student
        [HttpPost]
        public async Task<IActionResult> Unenroll(int studentId, int courseId)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student != null)
            {
                var course = student.Courses.FirstOrDefault(c => c.CourseId == courseId);
                if (course != null)
                {
                    student.Courses.Remove(course);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Enrollments));
        }

    }
}
