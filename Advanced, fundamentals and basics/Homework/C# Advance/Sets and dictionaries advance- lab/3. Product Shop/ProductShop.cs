using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> storesInfo = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(tokens.Length==1)
                {
                    break;
                }
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!storesInfo.ContainsKey(shop))
                {
                    storesInfo[shop] = new Dictionary<string, double>();
                }
                storesInfo[shop][product] = price;
            }

            foreach (var shop in storesInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
