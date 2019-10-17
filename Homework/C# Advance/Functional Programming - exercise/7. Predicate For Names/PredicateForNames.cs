using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> filterNames = n => n.Length <= nameLenght;

            string[] filteredNames = names.FindAll(filterNames).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,filteredNames));
                }
    }
}
