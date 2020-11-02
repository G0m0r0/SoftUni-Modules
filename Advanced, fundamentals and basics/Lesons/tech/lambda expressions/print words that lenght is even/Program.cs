using System;
using System.Collections.Generic;
using System.Linq;

namespace print_words_that_lenght_is_even
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordsLengh = Console.ReadLine()
                 .Split()
                 .Where(x => x.Length % 2 == 0)
                 .ToList();
            foreach (var item in wordsLengh)
            {
                Console.WriteLine(item);
            }
        }
    }
}
