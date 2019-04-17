using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderBy_dictionary
{
    class Program
    {
        static void Main(string[] args)
        { 
            var newCollection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToDictionary(x => x+"_", x => x)
                .OrderBy(x => x.Key);

            foreach (var item in newCollection)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
