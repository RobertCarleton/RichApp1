using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace RazorPages8.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pet = await _context.Pets
                .Include(p => p.User).ToListAsync();
        }
    }
}
