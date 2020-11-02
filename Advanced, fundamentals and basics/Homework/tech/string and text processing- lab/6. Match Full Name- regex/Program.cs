using System;
using System.Text.RegularExpressions;

namespace _6.Match_Full_Name__regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            var matches = Regex.Matches(names, @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b");
            Console.WriteLine(string.Join(" ",matches));
        }
    }
}
