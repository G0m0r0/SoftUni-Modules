using System;
using System.Linq;

namespace kamino_factory_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            int longestSubsequence = -1;
            int longestSubIndex = -1;
            int longestSubSum = -1;

            int[] sequence = new int[lenght];

            string input = Console.ReadLine();

            int indexOfLongest = 0;
            int indexOfSubSequence = 1;

            while(input!="Clone them!")
            {
                int[] currentSequence = input.Split('!').Select(int.Parse).ToArray();

                int Subsequence = 0;
                int SubIndex = -1;
                int SubSum = 0;

                int count = 0;
                for (int i = 0; i < lenght; i++)
                {
                    if (currentSequence[i] == 1)
                    {
                        count++;
                        SubSum++;
                    }
                    else
                    {
                        if (count > Subsequence)
                        {
                            Subsequence = count;
                            SubIndex = i - count;
                        }
                        else count = 0;
                    }
                }

                if(Subsequence>longestSubIndex)
                {
                    longestSubIndex = SubIndex;
                    longestSubsequence = Subsequence;
                    longestSubSum = SubSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSubSequence;
                }
                else if(Subsequence==longestSubsequence&&longestSubIndex>SubIndex)
                {
                    longestSubIndex = SubIndex;
                    longestSubsequence = Subsequence;
                    longestSubSum = SubSum;
                    sequence = currentSequence;
                }
                else if(Subsequence==longestSubsequence
                    &&longestSubIndex==SubIndex
                    &&longestSubSum<SubSum)
                {
                    longestSubSum = SubSum;
                    sequence = currentSequence;
                }
                indexOfSubSequence++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {indexOfLongest} with sum: {longestSubSum}.");
            Console.WriteLine(string.Join(' ',sequence));
        }
    }
}
