using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_figures
{
    class Program
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            double area;
            area = Math.PI * radius * radius;
            double perimetar = 2 * Math.PI * radius;
            Console.WriteLine("Area= {0}, Perimetar= {1}",area,perimetar);
            Console.Read();

        }
    }
}
