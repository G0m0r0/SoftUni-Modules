using System;
using System.Linq;

namespace kamino_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALenght = int.Parse(Console.ReadLine());

            int bestSequenceIndex = 0;
            int bestSequenceSum = 0;
            int[] bestDNAsequence = new int[DNALenght];

            string choice = Console.ReadLine();
            while (choice != "Clone them!")
            {
                int[] DNAsequence = choice.Split("!").Select(int.Parse).ToArray();
                int sequenceIndex = 0;
                int sequenceSum = 0;
                //int[] DNAsequence = new int[DNALenght];

                int countOnes = 0;
                int bestCountOnes = 0;
                for (int i = 0; i < DNAsequence.Length; i++)
                {
                    if(DNAsequence[i]==1)
                    {
                        sequenceSum++;
                        countOnes++;
                        if (countOnes > bestCountOnes)
                        {
                            bestCountOnes = countOnes;
                            bestDNAsequence = DNAsequence;
                        }
                    }
                    else
                    {
                        countOnes = 0;
                    }

                }

                

                choice = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ",bestDNAsequence));
        }
    
    }
}
