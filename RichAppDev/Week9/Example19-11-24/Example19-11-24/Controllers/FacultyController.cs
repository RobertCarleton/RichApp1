using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Controllers
{
    public class FacultyController : Controller
    {
        private readonly CollegeContext _context;

        public FacultyController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Faculty/ByDepartment
        public async Task<IActionResult> ByDepartment()
        {
            var faculty = await _context.Departments
                .Include(d => d.Faculty)
                .OrderBy(d => d.Name)
                .ToListAsync();

            return View(faculty);
        }
    }

}
