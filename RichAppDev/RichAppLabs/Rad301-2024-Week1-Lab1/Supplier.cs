using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    public class Supplier
    {
        public int SupplierID { get;set; }
        public string SupplierName { get;set; }
        public string SupplierAddressLine1 { get;set; }
        public string SupplierAddressLine2 { get; set; }
        public Supplier(int Id, string Name, string adr1, string adr2)
        {
            SupplierID = Id;
            SupplierName = Name;
            SupplierAddressLine1 = adr1;
            SupplierAddressLine2 = adr2;
        }
    }
}
