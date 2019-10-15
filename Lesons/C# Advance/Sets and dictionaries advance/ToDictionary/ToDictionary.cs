using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //list to string
            List<string> names = new List<string> { "Ivo", "Niki", "Ani", "Viktor" };
            var dictionary = names.ToDictionary(x => x, x => x.Length);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key+" -> "+item.Value);
            }
        }
    }
}
