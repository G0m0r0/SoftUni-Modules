using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int numberToDivide = int.Parse(Console.ReadLine());

            Predicate<int> filter = num => num % numberToDivide != 0;

            List<int> filterednumber = numbers.FindAll(filter);

            Console.WriteLine(string.Join(" ",filterednumber.ToArray().Reverse()));
        }
    }
}
