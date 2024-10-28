using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5L1.Data;
using W5L1.Models;

namespace W5L1.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly W5L1.Data.W5L1Context _context;

        public IndexModel(W5L1.Data.W5L1Context context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
