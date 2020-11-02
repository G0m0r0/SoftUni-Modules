using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //same for Sorted Dictionary
            //string- key //double- value
            var fruits = new SortedDictionary<string, double>()
            {
                {"niki",5 },
                {"ivan",10 },
                {"viktor",50 },
                {"simeon",17.5 }
            };

            //behave like add
            fruits["banana"] = 2.20;
            //
            fruits.Add("orange", 0.10);
            fruits.Remove("orange"); //remove the value too


            //check and print value by key faster
            //or ContainsValue() is slower because its liner search
            if (fruits.ContainsKey("banana"))
                Console.WriteLine(fruits["banana"]);

            //print
            foreach (var item in fruits)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
        }
    }
}
