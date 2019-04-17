using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double price = budget;
            string season = Console.ReadLine();
            string destination = " ";
            string place = " ";
            if (budget <= 100)
            {
                if (season == "winter")
                {
                    price *= 0.3;
                    place = "Hotel";
                }
                else if (season == "summer")
                {
                    price *= 0.7;
                    place = "Camp";
                }
                destination = "Bulgaria";
            }
            else if (budget <= 1000)
            {
                if (season == "winter")
                {
                    price *= 0.2;
                    place = "Hotel";
                }
                else if (season == "summer")
                {
                    price *= 0.6;
                    place = "Camp";
                }
                destination = "Balkans";
            }
            else
            {
                price *= 0.10;
                destination = "Europe";
                place = "Hotel";
            }
            Console.WriteLine("Somewhere in {0}",destination);
            Console.WriteLine("{0} - {1:f2}",place,Math.Abs(price-budget));
        }
    }
}
