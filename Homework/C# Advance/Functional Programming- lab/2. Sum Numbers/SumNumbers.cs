using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(Parse);
            Console.WriteLine(inputLine.Count());
            Console.WriteLine(inputLine.Sum());
        }

        static int Parse(string x)
        {
            int number = 0;
            foreach (var ch in x)
            {
                number *= 10;
                number += ch - 48;
            }
            return number;
        }
    }
}
