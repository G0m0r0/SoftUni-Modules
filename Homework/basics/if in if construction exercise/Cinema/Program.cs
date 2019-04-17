using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int coloum = int.Parse(Console.ReadLine());
            if (projection == "Premiere") Console.WriteLine($"{(row*coloum*12.00):f2} leva");
            else if (projection == "Normal") Console.WriteLine($"{(row*coloum*7.50):f2} leva");
            else if (projection == "Discount") Console.WriteLine($"{(row*coloum*5.00):f2} leva");
        }
    }
}
