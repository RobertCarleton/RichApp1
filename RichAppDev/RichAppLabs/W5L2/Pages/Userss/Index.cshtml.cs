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
    public class IndexModel : PageModel
    {
        private readonly W5L2.Data.W5L2Context _context;

        public IndexModel(W5L2.Data.W5L2Context context)
        {
            _context = context;
        }

        public IList<UserB> UserB { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserB = await _context.UserB
                .Include(u => u.UserA).ToListAsync();
        }
    }
}
