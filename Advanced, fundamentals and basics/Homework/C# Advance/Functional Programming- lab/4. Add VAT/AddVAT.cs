using System;
using System.Linq;

namespace _4._Add_VAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x=>double.Parse(x)*1.2);

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
