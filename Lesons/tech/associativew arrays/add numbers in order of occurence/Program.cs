using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace add_numbers_in_order_of_occurence
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            List<double> numDouble = new List<double>();
            foreach (var item in numbers)
            {
                numDouble.Add(double.Parse(item));
            }

            Dictionary<double, int> counts = new Dictionary<double, int>();
            foreach (var item in numDouble)
            {
                if (counts.ContainsKey(item))
                {
                    counts[item]++;
                }
                else
                {
                    counts.Add(item, 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
