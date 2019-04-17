using System;
using System.Collections.Generic;
using System.Linq;

namespace odd_occurrences
{
    class Program
    {


        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower());

            Dictionary<string, int> sequenceDictionary = new Dictionary<string, int>();
            foreach (var item in sequence)
            {
                if (sequenceDictionary.ContainsKey(item))
                {
                    sequenceDictionary[item]++;
                }
                else
                {
                    sequenceDictionary.Add(item, 1);
                }
            }

            foreach (var item in sequenceDictionary)
            {
                if (item.Value % 2 != 0)
                    // Console.WriteLine($"{item.Key} -> {item.Value}");
                    Console.Write($"{item.Key} ");
            }
            Console.WriteLine();
        }
    }
}
