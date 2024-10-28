using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using W5L2.Data;
using W5L2.Models;

namespace W5L2.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public EditModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public UserA UserA { get; set; } = default!;
        [BindProperty]
        public UserB UserB { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usera =  await _context.UserA.FirstOrDefaultAsync(m => m.ID == id);
            if (usera == null)
            {
                return NotFound();
            }
            UserA = usera;
            UserA.UserB = UserB;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAExists(UserA.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserAExists(int id)
        {
            return _context.UserA.Any(e => e.ID == id);
        }
    }
}
