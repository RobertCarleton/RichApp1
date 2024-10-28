using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W4L1P3;
using W4L1P3.Data;

namespace W4L1P3.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly W4L1P3.Data.W4L1P3Context _context;

        public DetailsModel(W4L1P3.Data.W4L1P3Context context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}
