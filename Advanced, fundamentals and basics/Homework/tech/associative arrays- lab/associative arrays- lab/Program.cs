using System;
using System.Collections.Generic;
using System.Linq;

namespace associative_arrays__lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            SortedDictionary<double,int> ListDictionary = new SortedDictionary<double, int>();
            foreach (var item in listInt)
            {
                if(!ListDictionary.ContainsKey(item))
                {
                    ListDictionary.Add(item, 1);
                }
                else
                {
                    ListDictionary[item]++;
                }
            }
            //ListDictionary.OrderBy(x => x.Key);
            foreach (var item in ListDictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
