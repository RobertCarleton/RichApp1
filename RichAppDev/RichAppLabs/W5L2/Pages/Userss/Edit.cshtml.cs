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

namespace W5L2.Pages.Userss
{
    public class EditModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public EditModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public UserB UserB { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userb =  await _context.UserB.FirstOrDefaultAsync(m => m.UserID == id);
            if (userb == null)
            {
                return NotFound();
            }
            UserB = userb;
           ViewData["UserID"] = new SelectList(_context.UserA, "ID", "FName");
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

            _context.Attach(UserB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBExists(UserB.UserID))
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

        private bool UserBExists(int id)
        {
            return _context.UserB.Any(e => e.UserID == id);
        }
    }
}
