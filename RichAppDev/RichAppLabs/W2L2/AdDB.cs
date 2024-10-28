using Microsoft.EntityFrameworkCore;
namespace W2L2
{
    public class AdDB : DbContext
    {
        public AdDB(DbContextOptions<AdDB> options) : base(options) { }
        public DbSet<Ad> Ads => Set<Ad>();
    }
}
