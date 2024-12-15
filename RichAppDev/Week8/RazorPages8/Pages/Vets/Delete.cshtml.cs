using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;
using Microsoft.AspNetCore.Authorization;

namespace RazorPages8.Pages.Vets
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets.FindAsync(id);
            if (vet != null)
            {
                Vet = vet;
                _context.Vets.Remove(Vet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
