using System;
using System.Collections.Generic;
using System.Linq;

namespace kamino_factory_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALengh = int.Parse(Console.ReadLine());

            int bestSubLengh = 0;
            int bestIndex = 0;
            List<int> bestDNA = new List<int>();
            int bestCount = 0;

            int count = 0;
            string command = Console.ReadLine();
            while (command != "Clone them!")
            {
                count++;
                int[] commandInt = command.Split("!").Select(int.Parse).ToArray();
                int index = 0;
                int subLenght = LongestSubsequenceOfOnes(commandInt, ref index);
                if (subLenght > bestSubLengh)
                {
                    bestSubLengh = subLenght;
                    bestIndex = index;
                    bestDNA = commandInt.ToList();
                    bestCount = count;
                }
                else if (subLenght == bestSubLengh)
                {
                    if (bestIndex > index)
                    {
                        bestIndex = index;
                        bestDNA = commandInt.ToList();
                        bestCount = count;
                    }
                    else if(bestIndex==index)
                    {
                        int sumOld = bestDNA.Sum();
                        int currentSum = commandInt.Sum();
                        if (currentSum > sumOld)
                        {
                            bestDNA = commandInt.ToList();
                            bestCount = count;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestCount} with sum: {bestDNA.Sum()}.\n{string.Join(" ",bestDNA)}");
        }

        private static int LongestSubsequenceOfOnes(int[] command, ref int bestIndex)
        {
            int count = 0;
            int bestCount = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 1)
                {
                    count++;
                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestIndex = i;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            if (bestCount > 0)
                bestIndex -= bestCount - 1;
            else
                bestIndex = -1;
            return bestCount;
        }
    }
}
