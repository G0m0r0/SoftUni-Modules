using System;

namespace orders
{
    class Program
    {
        static void ChooseProduct(string product,double quantity)
        {
            switch (product)
            {
                case "water": Console.WriteLine($"{(1*quantity):f2}"); break;
                case "coffee": Console.WriteLine($"{(1.5 *quantity):f2}"); break;
                case "coke": Console.WriteLine($"{(1.4 *quantity):f2}"); break;
                case "snacks": Console.WriteLine($"{(2 *quantity):f2}"); break;                                   
            }

        }
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            ChooseProduct(product, quantity);
        }
    }
}
