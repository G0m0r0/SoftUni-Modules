using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = tokens[0];
            int m = tokens[1];
            if(n<=0||m<=0)
            {
                return;
            }

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();


            for(int i = 0; i < n+m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(i<n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    if(firstSet.Contains(number))
                    {
                        secondSet.Add(number);
                    }
                }
            }

            Console.WriteLine(string.Join(" ",secondSet));
        }
    }
}
