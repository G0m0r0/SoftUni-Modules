using System;
using System.Collections.Generic;
using System.Linq;

namespace associative_arrays__exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputStr = Console.ReadLine()
                .Where(x => x != ' ')
                .ToArray();

            var strInput = new Dictionary<char, int>();
            // for (int i = 0; i < inputStr.Length; i++)
            // {
            //     if (strInput.ContainsKey(inputStr[i]))
            //     {
            //         strInput[inputStr[i]]++;
            //     }
            //     else
            //     {
            //         strInput.Add(inputStr[i], 1);
            //     }
            // }
            foreach (var item in inputStr)
            {
                if(!strInput.ContainsKey(item))
                {
                    strInput[item] = 0;
                }
                strInput[item]++;
            }

            foreach (var item in strInput)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
