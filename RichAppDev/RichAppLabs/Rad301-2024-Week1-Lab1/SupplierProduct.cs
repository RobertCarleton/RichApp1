using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    public class SupplierProduct
    {
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public DateTime Date { get; set; }

        public SupplierProduct(int supplierID, int productID, DateTime date)
        {
            SupplierID = supplierID;
            ProductID = productID;
            Date = date;
        }
    }
}
