using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    public class ProductModel
    {
        public Supplier[] supplier = new Supplier[2];
        public Product[] products = new Product[4];
        public Category[] category = new Category[2];
        public SupplierProduct[] supplierProduct = new SupplierProduct[4];

        #region PK's & FK's
        int sup1ID = 1;
        int sup2ID = 2;
        int prod1ID = 1;
        int prod2ID = 2;
        int prod3ID = 3;
        int prod4ID = 4;
        int cat1ID = 1;
        int cat2ID = 2;
        #endregion

        public ProductModel() 
        {
            supplier[0] = new Supplier(sup1ID, "ACME", "Collooney", "Sligo");
            supplier[1] = new Supplier(sup2ID, "Swift Electric", "Finglas", "Dublin");

            products[0] = new Product(prod1ID, "9 Inch Nails", 200, 0.1f, cat1ID);
            products[1] = new Product(prod2ID, "9 Inch Bolts", 120, 0.2f, cat1ID);
            products[2] = new Product(prod3ID, "Chimney Hoover", 10, 100.30f, cat2ID);
            products[3] = new Product(prod4ID, "Washing Machine", 7, 399.50f, cat2ID);

            category[0] = new Category(cat1ID, "Hardware");
            category[1] = new Category(cat2ID, "Electrical Appliances");

            supplierProduct[0] = new SupplierProduct(sup1ID, prod1ID, new DateTime(2012, 12, 12));
            supplierProduct[1] = new SupplierProduct(sup1ID, prod2ID, new DateTime(2017, 08, 13));
            supplierProduct[2] = new SupplierProduct(sup2ID, prod3ID, new DateTime(2022, 09, 09));
            supplierProduct[3] = new SupplierProduct(sup2ID, prod4ID, new DateTime(2024, 04, 11));

            //Q6(a)
            Console.WriteLine("Q6(a)");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine((category[i].ID, category[i].Description).ToString());
            }

            //Q6(b)
            Console.WriteLine("Q6(b)");
            for (int i = 0;i < 4; i++)
            {
                Console.WriteLine((products[i].ProductID, products[i].Description, " #" + products[i].QuantityInStock, " €" + products[i].UnitPrice,
                    products[i].CategoryID).ToString());
            }

            //Q6(c)
            Console.WriteLine("Q6(c)");
            var pds = products.Where(p => p.QuantityInStock <= 100).ToList();
            //for (int i = 0; i < pds.Count; i++)
            foreach (var products in pds)
            {
                Console.WriteLine((products.ProductID, products.Description, " #" + products.QuantityInStock, " €" + products.UnitPrice,
                    products.CategoryID).ToString());
            }

            //Q7(a)
            Console.WriteLine("Q7(a)");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine((products[i].ProductID, products[i].Description, " €" + products[i].QuantityInStock * products[i].UnitPrice,
                    products[i].CategoryID).ToString());
            }

            //Q7(b)
            Console.WriteLine("Q7(b)");
            var hardwareProducts = from product in products
                                   join category in category
                                   on product.CategoryID equals category.ID
                                   where category.Description == "Hardware"
                                   select new { product.ProductID, product.Description, product.QuantityInStock, product.UnitPrice, product.CategoryID };
            foreach (var product in hardwareProducts)
            {
                Console.WriteLine((product.ProductID, product.Description, " #" + product.QuantityInStock, " €" + product.UnitPrice,
                    product.CategoryID).ToString());
            }

            //Q7(c)
            Console.WriteLine("Q7(c)");
            var suppProd = from supp in supplier
                                   join sproduct in supplierProduct on supp.SupplierID equals sproduct.SupplierID
                                   orderby supp.SupplierName
                                   select new {sproduct.SupplierID, supp.SupplierName, sproduct.ProductID};
            foreach (var supp in suppProd)
            {
                Console.WriteLine((supp.SupplierID, supp.SupplierName, supp.ProductID).ToString());
            }
        }



    }
}
