using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            if (flower == "Dahlias")
            {
                price = number * 3.8;
                if (number > 90) price -= (price * 0.15);
            }
            else if (flower == "Roses")
            {
                price = number * 5;
                if (number > 80) price -= (price * 0.1);
            }
            else if (flower == "Tulips")
            {
                price = number * 2.8;
                if (number > 80) price -= (price * 0.15);
            }
            else if (flower == "Narcissus")
            {
                price = number * 3;
                if (number < 120) price += (price * 0.15);
            }
            else if (flower == "Gladiolus")
            {
                price = number * 2.5;
                if (number < 80) price += (price * 0.2);
            }
            if (budget >= price) Console.WriteLine("Hey, you have a great garden with {0} {1} and {2:f2} leva left. ",number,flower,(budget-price));
            else Console.WriteLine("Not enough money, you need {0:F2} leva more.",(price-budget));
        }
    }
}
