using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5L2.Data;
using W5L2.Models;

namespace W5L2.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public DetailsModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        public UserA UserA { get; set; } = default!;
        public UserB UserB { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserA.UserB = UserB;
            var usera = await _context.UserA
                .Include(u => u.UserB)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usera == null)
            {
                return NotFound();
            }
            else
            {
                UserA = usera;
            }
            return Page();
        }
    }
}
