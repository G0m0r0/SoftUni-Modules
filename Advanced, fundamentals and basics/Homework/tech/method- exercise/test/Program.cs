using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(array.Length);

        }
    }
}
