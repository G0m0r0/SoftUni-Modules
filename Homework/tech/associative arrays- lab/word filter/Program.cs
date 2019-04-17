using System;
using System.Linq;

namespace word_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var evenWords = Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToList();

            foreach (var item in evenWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
