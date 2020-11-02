using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            firstList.Insert(1, secondList[3]);

            Console.WriteLine(string.Join(" ",firstList));
        }
    }
}
