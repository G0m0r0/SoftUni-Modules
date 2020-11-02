using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss__trick_2
{
    class Program
    {
        //wrong idea!!!!!!!!!!!!
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int lastIndex = listNumbers.Count / 2;
            while(lastIndex/2>0)
            {

            }
        }
    }
}
