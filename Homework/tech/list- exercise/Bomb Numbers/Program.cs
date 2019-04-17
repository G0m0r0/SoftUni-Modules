using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int[] numberAndPower = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int bomb = numberAndPower[0];
            int blast = numberAndPower[1];

            for (int i = 0; i < numbList.Count; i++)
            {
                if (numbList[i] == bomb)
                    BombRange(numbList, blast, i);
            }
            //Console.WriteLine(string.Join(" ",numbList));
            Console.WriteLine(numbList.Sum());
        }

        private static void BombRange(List<int> numbList, int blast, int place)
        {
            int start = place - blast;
            int finish = place+blast+1;

            if (place - blast < 0)
                start = 0;

            if (place + blast + 1 > numbList.Count)
                finish = numbList.Count;

            for (int i = start; i < finish; i++)
            {
                numbList[i] = 0;
            }
        }
    }
}
