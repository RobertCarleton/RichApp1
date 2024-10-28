using Microsoft.EntityFrameworkCore;
using W4L1P2.Models;
namespace W4L1P2.Data
{
    public class AdDB : DbContext
    {
        public AdDB(DbContextOptions<AdDB> options) : base(options) { }
        public DbSet<Ad> Ads => Set<Ad>();
    }
}
