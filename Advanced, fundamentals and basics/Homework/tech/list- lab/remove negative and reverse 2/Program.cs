using System;
using System.Collections.Generic;
using System.Linq;

namespace remove_negative_and_reverse_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
           .Split(" ")
           .Select(int.Parse)
           .ToList();

            numberList.RemoveAll(x => x < 0);
            numberList.Reverse();
            if(numberList.Count==0)
                Console.WriteLine("empty");
            else
            Console.WriteLine(string.Join(" ",numberList));
        }
    }
}
