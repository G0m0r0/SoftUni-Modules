using System;
using System.Text.RegularExpressions;

namespace _8.Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            var filteredNumbers = Regex.Matches(numbers, @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))");

            Console.WriteLine(string.Join(" ",filteredNumbers));
        }
    }
}
