using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W4L1P3;
using W4L1P3.Data;

namespace W4L1P3.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly W4L1P3.Data.W4L1P3Context _context;

        public IndexModel(W4L1P3.Data.W4L1P3Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
