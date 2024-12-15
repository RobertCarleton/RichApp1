using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace RazorPages8.Pages.Vets
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Vet Vet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets.FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }
            else
            {
                Vet = vet;
            }
            return Page();
        }
    }
}
