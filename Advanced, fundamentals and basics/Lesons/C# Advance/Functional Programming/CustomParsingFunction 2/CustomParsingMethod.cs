using System;
using System.Linq;

namespace CustomParsingFunction_2
{
    class CustomParsingMethod
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parsing = n => int.Parse(n);
            int[] numbers = input.Split(", ").Select(parsing).ToArray();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
