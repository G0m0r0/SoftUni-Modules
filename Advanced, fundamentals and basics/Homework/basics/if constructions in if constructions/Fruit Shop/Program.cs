using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double amount =double.Parse( Console.ReadLine());
            if (day == "Sunday" || day == "Saturday")
            {
                if (product == "banana") Console.WriteLine(amount * 2.7);
                else if (product == "apple") Console.WriteLine(amount * 1.25);
                else if (product == "orange") Console.WriteLine(amount * 0.9);
                else if (product == "grapefruit") Console.WriteLine(amount * 1.6);
                else if (product == "kiwi") Console.WriteLine(amount * 3);
                else if (product == "pineapple") Console.WriteLine(amount * 5.6);
                else if (product == "grapes") Console.WriteLine(amount * 4.2);
                else Console.WriteLine("error");
            }
             else if(day=="Monday"||day=="Tuesday"||day=="Wednesday"||day=="Thursday"||day=="Friday")
            {
                if (product == "banana") Console.WriteLine(amount *2.5 );
                else if (product == "apple") Console.WriteLine(amount * 1.2);
                else if (product == "orange") Console.WriteLine(amount * 0.85);
                else if (product == "grapefruit") Console.WriteLine(amount * 1.45);
                else if (product == "kiwi") Console.WriteLine(amount * 2.7);
                else if (product == "pineapple") Console.WriteLine(amount * 5.5);
                else if (product == "grapes") Console.WriteLine(amount * 3.85);
                else Console.WriteLine("error");
            }
            else Console.WriteLine("error");
        }
    }
}
