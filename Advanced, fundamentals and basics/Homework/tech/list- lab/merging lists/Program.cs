using System;
using System.Collections.Generic;
using System.Linq;

namespace merging_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> resultList = new List<int>();

            for (int i = 0; i < Math.Max(firstList.Count,secondList.Count); i++)
            {
                if(i<firstList.Count)
                {
                    resultList.Add(firstList[i]);
                }
                if(i<secondList.Count)
                {
                    resultList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ",resultList));
        }
    }
}
