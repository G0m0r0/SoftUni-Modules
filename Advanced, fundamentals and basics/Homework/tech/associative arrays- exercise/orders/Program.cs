using System;
using System.Collections.Generic;
using System.Linq;

namespace orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, double[]>();

            string[] token = Console.ReadLine().Split();
            while (token[0] != "buy")
            {
                double[] priceQuantity = { double.Parse(token[1]), double.Parse(token[2]) };
                if (!products.ContainsKey(token[0]))
                {
                    products[token[0]] = new double[] { priceQuantity[0],priceQuantity[1] };
                }
                else
                {
                    priceQuantity[1] = products[token[0]][1] + priceQuantity[1];
                    products[token[0]]=priceQuantity ;
                }
                token = Console.ReadLine().Split();
            }
            foreach (var kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> {(kvp.Value[0]*kvp.Value[1]):f2}");
            }
        }
    }
}
