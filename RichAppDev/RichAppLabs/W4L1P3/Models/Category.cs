using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4L1P3
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        
    }
}
