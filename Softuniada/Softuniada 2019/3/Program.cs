using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Softuniada_2019
{
    class Program
    {
        static void Main()
        {
            List<int> firstSequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = string.Empty;
            int sum = 0;
            while ((command = Console.ReadLine()) != "nexus")
            {
                string[] token = command.Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);
                int firstInd1 = int.Parse(token[0]);
                int secondInd2 = int.Parse(token[1]);
                int firstInd2 = int.Parse(token[2]);
                int secondInd1 = int.Parse(token[3]);
                
                //check condition
                if(!(firstInd1<secondInd2&&secondInd1<firstInd2&&firstInd1<firstInd2))
                { 
                    continue;
                }
                //sum
                sum = firstSequence[firstInd1] + firstSequence[firstInd2] + secondSequence[secondInd1] + secondSequence[secondInd2];
                for (int i = firstInd1; i <= firstInd2; i++)
                {
                    firstSequence.RemoveAt(firstInd1);
                }
                for (int i = secondInd1; i <= secondInd2; i++)
                {
                    secondSequence.RemoveAt(secondInd1);
                }
                for (int i = 0; i < firstSequence.Count; i++)
                {
                    firstSequence[i] += sum;
                }
                for (int i = 0; i < secondSequence.Count; i++)
                {
                    secondSequence[i] += sum;
                }
            }
    
            Console.WriteLine(string.Join(", ",firstSequence));
            Console.WriteLine(string.Join(", ",secondSequence));
        }
    }
}
