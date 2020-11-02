using System;
using System.Collections.Generic;
using System.Linq;

namespace present_delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> EvenIntegers = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split().ToArray();
            int sandaIndex = 0;
            while (command[0] != "Merry")
            {
                int jumpLenght = int.Parse(command[1]);
                sandaIndex += jumpLenght;
                if (sandaIndex > EvenIntegers.Count - 1)
                {
                    while(sandaIndex>EvenIntegers.Count-1)
                    sandaIndex = sandaIndex - EvenIntegers.Count;
                }

                if (EvenIntegers[sandaIndex] == 0)
                {
                    EvenIntegers[sandaIndex] -= 2;
                    Console.WriteLine($"House {sandaIndex} will have a Merry Christmas.");
                }
                else
                    EvenIntegers[sandaIndex] -= 2;

                //Console.WriteLine(sandaIndex);
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"Santa's last position was {sandaIndex}.");

            int unsuccessful = 0;
            for (int i = 0; i < EvenIntegers.Count; i++)
            {
                if (EvenIntegers[i] > 0)
                    unsuccessful++;
            }
            if (unsuccessful == 0)
               Console.WriteLine("Mission was successful.");
            else
                Console.WriteLine($"Santa has failed {unsuccessful} houses.");


        }
    }
}
