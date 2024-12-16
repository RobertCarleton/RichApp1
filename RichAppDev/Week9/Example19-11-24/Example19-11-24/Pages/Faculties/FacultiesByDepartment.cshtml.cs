using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Pages.Faculties
{
    public class FacultiesByDepartmentModel : PageModel
    {
        private readonly CollegeContext _context;

        public FacultiesByDepartmentModel(CollegeContext context)
        {
            _context = context;
        }

        public List<DepartmentFacultyGroup> FacultiesByDepartment { get; set; }

        public void OnGet()
        {
            FacultiesByDepartment = _context.Departments
                .Include(d => d.Faculty) // Include faculty members in the query
                .OrderBy(d => d.Name) // Sort departments alphabetically
                .Select(d => new DepartmentFacultyGroup
                {
                    DepartmentName = d.Name,
                    Faculties = d.Faculty.OrderBy(f => f.LastName).ToList()
                })
                .ToList();
        }
    }

    public class DepartmentFacultyGroup
    {
        public string DepartmentName { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
