using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    public class Category
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Category(int Id, string desc)
        {
            ID = Id;
            Description = desc;
        }

    }
}
