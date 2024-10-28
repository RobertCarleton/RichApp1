using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5L2.Data;
using W5L2.Models;

namespace W5L2.Pages.Userss
{
    public class DetailsModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public DetailsModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        public UserB UserB { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userb = await _context.UserB.FirstOrDefaultAsync(m => m.UserID == id);
            if (userb == null)
            {
                return NotFound();
            }
            else
            {
                UserB = userb;
            }
            return Page();
        }
    }
}
