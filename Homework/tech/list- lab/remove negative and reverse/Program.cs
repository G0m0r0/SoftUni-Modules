using System;
using System.Collections.Generic;
using System.Linq;

namespace remove_negative_and_reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .Where(x => x > 0)
                .ToList();
            if (numberList.Count == 0)
                Console.WriteLine("empty");
            else
            {
                numberList.Reverse();
                foreach (var item in numberList)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
