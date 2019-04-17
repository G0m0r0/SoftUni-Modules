using System;
using System.Collections.Generic;
using System.Linq;

namespace Hello_france
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();
            decimal budget = decimal.Parse(Console.ReadLine());

            List<decimal> newItemPrice = new List<decimal>();
            decimal profit = 0;
            for (int i = 0; i < items.Count; i++)
            {
                string[] token = items[i].Split("->").ToArray();
                switch (token[0])
                {
                    case "Clothes":
                        if (decimal.Parse(token[1]) > 50m)
                            continue;
                        break;
                    case "Shoes":
                        if (decimal.Parse(token[1]) > 35m)
                            continue;
                        break;
                    case "Accessories":
                        if (decimal.Parse(token[1]) > 20.50m)
                            continue;
                        break;
                }

                if (budget - decimal.Parse(token[1]) < 0)
                {
                    continue;
                }

                budget -= decimal.Parse(token[1]);
                
                profit += decimal.Parse(token[1]) * 0.4m;
                //profit=Math.Round(profit,2,MidpointRounding.AwayFromZero);

                decimal newPrice = decimal.Parse(token[1]) + decimal.Parse(token[1]) * 0.4m;
                newPrice = Math.Round(newPrice, 2, MidpointRounding.AwayFromZero);

                newItemPrice.Add(newPrice);
            }
            foreach (var item in newItemPrice)
            {
                Console.Write($"{(item):f2}"+" ");
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {(Math.Round(profit, 2, MidpointRounding.AwayFromZero)):f2}");
            if (newItemPrice.Sum() + budget >= 150m)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
