using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example19_11_24.Pages.Students
{
    public class NotEnrolledModel : PageModel
    {
        private readonly CollegeContext _context;

        public NotEnrolledModel(CollegeContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }

        public void OnGet()
        {
            Students = _context.Students
                .Where(s => !s.Courses.Any())
                .ToList();
        }
    }
}
