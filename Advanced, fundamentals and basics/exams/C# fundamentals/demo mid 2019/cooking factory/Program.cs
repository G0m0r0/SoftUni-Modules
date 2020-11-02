using System;
using System.Collections.Generic;
using System.Linq;

namespace cooking_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int bestSum = -10000000;
            List<int> bestBread = new List<int>();
            while (command!="Bake It!")
            {
                List<int> breadQuality = command.Split("#").Select(int.Parse).ToList();
                int sum = breadQuality.Sum();
                if(sum>bestSum)
                {
                    bestSum = sum;
                    bestBread = breadQuality;
                }
                else if(sum==bestSum)
                {
                    double avrgsum = sum / (double)breadQuality.Count();
                    double avrgBest = sum / (double)bestBread.Count();
                    if(avrgsum>avrgBest)
                    {
                        bestBread = breadQuality;
                    }
                    else if(avrgBest==avrgsum)
                    {
                        int lenght = breadQuality.Count;
                        int bestlenght = bestBread.Count;
                        if(lenght<bestlenght)
                        {    
                            bestBread = breadQuality;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {bestSum}");
            Console.WriteLine(string.Join(" ",bestBread));
        }
    }
}
