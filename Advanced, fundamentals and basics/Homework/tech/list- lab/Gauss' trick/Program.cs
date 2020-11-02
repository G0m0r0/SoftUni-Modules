using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss__trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            //int last = listNumbers.Count;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (i == listNumbers.Count - 1)
                    break;
                    listNumbers[i] = listNumbers[i] + listNumbers[listNumbers.Count-1];
                listNumbers.RemoveAt(listNumbers.Count-1);             
            }
            Console.WriteLine(string.Join(" ",listNumbers));
        }
    }
}
