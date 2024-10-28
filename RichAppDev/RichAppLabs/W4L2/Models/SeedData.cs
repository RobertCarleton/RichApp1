using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using W4L1P2.Data;
using W4L1P2.Models;

namespace W4L1P2.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AdDB(
            serviceProvider.GetRequiredService<
                DbContextOptions<AdDB>>()))
        {
            if (context == null || context.Ads == null)
            {
                throw new ArgumentNullException("Null AdDB");
            }

            // Look for any movies.
            if (context.Ads.Any())
            {
                return;   // DB has been seeded
            }

            context.Ads.AddRange(
                new Ad
                {
                    AdName = "Plastic Surgery",
                    SellerName = "Michael Jackson",
                    Description = "Not good",
                    CategoryName = "Surgical",
                    Price = 7.99f,
                    Type = "Paid"
                },
                new Ad
                {
                    AdName = "Pizza",
                    SellerName = "Roberto's",
                    Description = "Very good",
                    CategoryName = "Fast Food",
                    Price = 0f,
                    Type = "Free"
                }
            );
            context.SaveChanges();
        }
    }
}