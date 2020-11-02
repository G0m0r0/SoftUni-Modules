using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = Console.ReadLine().Split().Select(int.Parse).ToList();

            testList.RemoveAt(5);

            Console.WriteLine(string.Join(" ",testList));
            
        }
    }
}
