using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductModel model = new ProductModel();
            Console.WriteLine(model);
            Console.ReadKey();
        }
    }
}
