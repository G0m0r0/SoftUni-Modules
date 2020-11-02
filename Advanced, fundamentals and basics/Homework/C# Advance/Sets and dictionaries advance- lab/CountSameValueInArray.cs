using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_dictionaries_advance
{
    class Store
    {
        //nested dictionaries
        static void Main(string[] args)
        {

            double[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countValueDictionary = new Dictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!countValueDictionary.ContainsKey(array[i]))
                {
                    countValueDictionary[array[i]] = 1;
                }
                else
                {
                    countValueDictionary[array[i]]++;
                }
            }

            foreach (var kvp in countValueDictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
