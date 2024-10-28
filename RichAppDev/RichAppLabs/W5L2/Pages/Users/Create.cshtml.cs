using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using W5L2.Data;
using W5L2.Models;

namespace W5L2.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public CreateModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserA UserA { get; set; } = default!;
        [BindProperty]
        public UserB UserB { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserA.UserB = UserB;
            _context.UserA.Add(UserA);
            //_context.UserB.Add(UserB);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
