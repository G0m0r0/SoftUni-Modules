using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> countCh = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(!countCh.ContainsKey(input[i]))
                {
                    countCh[input[i]] = 0;
                }
                countCh[input[i]]++;
            }

            foreach (var symbol in countCh.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
