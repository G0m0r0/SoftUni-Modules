using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Hello_france
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split('|').ToList();
            decimal budget = decimal.Parse(Console.ReadLine());

            decimal profit = 0;
            List<decimal> newPrices = new List<decimal>();
            for (int i = 0; i < items.Count; i++)
            {
                string[] command = items[i].Split("->").ToArray();
                switch (command[0])
                {
                    case "Clothes":
                        if (decimal.Parse(command[1]) > 50.00m)
                            continue;
                        break;
                    case "Shoes":
                        if (decimal.Parse(command[1]) > 35.00m)
                            continue;
                        break;
                    case "Accessories":
                        if (decimal.Parse(command[1]) > 20.50m)
                            continue;
                        break;
                    default:
                        break;
                }
                if (budget - decimal.Parse(command[1]) < 0)
                    continue;
                else
                    budget -= decimal.Parse(command[1]);

                decimal newPrice = decimal.Parse(command[1]) + decimal.Parse(command[1]) * 0.4m;
                profit+=decimal.Parse(command[1])

            }
        }
    }
}
