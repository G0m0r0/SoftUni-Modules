using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> PrintSum = x => x.Sum();
            Func<int[], int> PrintNumberOfElements = x => x.Count();

            Console.WriteLine(PrintSum(numbers));
            Console.WriteLine(PrintNumberOfElements);
        }
    }
}
