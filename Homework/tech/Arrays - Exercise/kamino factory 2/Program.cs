using System;
using System.Linq;
namespace kamino_factory_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequenceDNA = new int[n];
            //best Index SumDNA sequenceDNA
            int bestIndex = 0;
            int bestSequenceSum = 0;
            int[] bestDNA = new int[n];

            string choice = string.Empty;
            while(true)
            {
                if (choice == "Clone them!")
                    break;
                else sequenceDNA = choice.Split('!').Select(int.Parse).ToArray();
                bestIndex++;

                int countOne = 0;
                int startingIndex = 0;

                int groupOfOne=0;
                int oldGroupOfOne = 0;
                
                for (int i = 0; i < n; i++)
                {
                    if (sequenceDNA[i] == 1)
                    {
                        if (startingIndex == 0 && i != 0)
                            startingIndex = i;
                        countOne++;
                        groupOfOne++;
                        if (groupOfOne > oldGroupOfOne)
                            oldGroupOfOne = groupOfOne;
                    }
                    else groupOfOne = 0;
                }

                if(oldGroupOfOne>)
                //if bestSequenceSum=countOne;
                //if 
                //if bestDNA=sequenceDNA
            }
            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSequenceSum}.\n{string.Join(' ',bestDNA)}");
        }
    }
}
