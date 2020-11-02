using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double fishermen = double.Parse(Console.ReadLine());
            double price = 0;
            if (season == "Spring")
                price = 3000;
            else if (season == "Summer" || season == "Autumn")
                price = 4200;
            else if (season == "Winter")
                price = 2600;
            if (fishermen <= 6)
                price *= 0.9;
            else if (fishermen <= 11)
                price *= 0.85;
            else if (fishermen > 11)
                price *= 0.75;
            if (fishermen % 2 == 0 && season != "Autumn")
                price *=0.95;
            if (budget >= price)
                Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            else Console.WriteLine($"Not enough money! You need {(price - budget):f2} leva.");
        }
    }
}
