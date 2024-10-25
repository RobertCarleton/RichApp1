using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get;set; }
        public float UnitPrice { get; set; }
        public int CategoryID { get; set; }

        public Product (int productID, string description, int quantityInStock, float unitPrice, int categoryID)
        {
            ProductID = productID;
            Description = description;
            QuantityInStock = quantityInStock;
            UnitPrice = unitPrice;
            CategoryID = categoryID;
        }
    }
}
