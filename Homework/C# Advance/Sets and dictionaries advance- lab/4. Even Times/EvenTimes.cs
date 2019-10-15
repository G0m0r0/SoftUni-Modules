using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfTimes = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenTimes = new Dictionary<int, int>();

            for (int i = 0; i < numOfTimes; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!evenTimes.ContainsKey(number))
                {
                    evenTimes[number] = 0;
                }
                evenTimes[number]++;
            }

            foreach (var num in evenTimes)
            {
                if(num.Value%2==0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
