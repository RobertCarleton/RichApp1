using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W4L1P3;

namespace W4L1P3.Data
{
    public class W4L1P3Context : DbContext
    {
        public W4L1P3Context (DbContextOptions<W4L1P3Context> options)
            : base(options)
        {
        }

        public DbSet<W4L1P3.Supplier> Supplier { get; set; } = default!;
        public DbSet<W4L1P3.Product> Product { get; set; } = default!;
        public DbSet<W4L1P3.Category> Category { get; set; } = default!;
    }
}
