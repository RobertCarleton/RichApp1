using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using W4L1P3;
using W4L1P3.Data;

namespace W4L1P3.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new W4L1P3Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<W4L1P3Context>>()))
        {
            if (context == null || context.Product == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            context.Product.AddRange(
                new Product
                {
                    ProductID = 1,
                    CategoryID = 1,
                    Description = "9 Inch Bolts",
                    UnitPrice = 0.1f,
                    dateFirstIssued = DateTime.Parse("2012-12-12"),
                    QuantityInStock = 200
                }
            );
            if (context.Supplier.Any())
            {
                return;   // DB has been seeded
            }
            context.Supplier.AddRange(
                new Supplier
                {
                    SupplierID = 1,
                    SupplierName = "ACME",
                    SupplierAddressLine1 = "Collooney",
                    SupplierAddressLine2 = "Sligo"
                }
            );
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }
            context.Category.AddRange(
                new Category
                {
                    CategoryID = 1,
                    Description = "Hardware"
                }
            );
            //context.SaveChanges();
        }
    }
}