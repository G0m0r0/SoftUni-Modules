using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] token = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = token[0];
            int m = token[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i <n ; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (first.Contains(number))
                {
                    second.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ",second));
        }
    }
}
