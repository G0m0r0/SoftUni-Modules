using System;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var numList = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x=>x)
                .Take(3)
                .ToList();


            Console.WriteLine(string.Join(" ",numList));
        }
    }
}
