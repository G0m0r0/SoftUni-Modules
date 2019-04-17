using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());    
            string vipOrNormal = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double price = 0;
            if (people >= 1 && people <= 4) budget -= (budget * 0.75);
            else if (people > 4 && people <= 9) budget -= (budget * 0.6);
            else if (people > 9 && people <= 24) budget -= (budget * 0.5);
            else if (people > 24 && people <= 49) budget -= (budget * 0.4);
            else if (people >= 50) budget -= (budget * 0.25);
            if (vipOrNormal == "VIP")
                price= 499.99;
            else price -= 249.99;
            Console.WriteLine(price);
            Console.WriteLine(budget);
            if (price <= budget) Console.WriteLine($"Yes! You have {(budget - price):f2} leva left.");
            else Console.WriteLine($"Not enough money! You need {(price - budget):f2} leva.");
        }
    }
}
