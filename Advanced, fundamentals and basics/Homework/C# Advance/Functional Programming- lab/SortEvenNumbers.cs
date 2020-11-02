using System;
using System.Linq;

namespace Functional_Programming__lab
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Func<int, bool> filterEven = x => x % 2 == 0;
            var evenNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(filterEven)
                .OrderBy(x=>x);

            Console.WriteLine(string.Join(", ",evenNumbers));
        }
    }
}
