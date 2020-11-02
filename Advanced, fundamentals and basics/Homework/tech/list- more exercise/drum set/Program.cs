using System;
using System.Collections.Generic;
using System.Linq;

namespace drum_set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> copyDrumset = new List<int>();
            for (int i = 0; i < drumSet.Count; i++)
            {
                copyDrumset.Add(drumSet[i]);
            }

            string choice = Console.ReadLine();
            while (choice!="Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(choice);
                ReduceDrumsetQuality(drumSet, hitPower,ref savings,copyDrumset);                

                choice = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }

        private static void ReduceDrumsetQuality(List<int> drumSet, int hitPower,ref double savings,List<int> copyDrumset)
        {
            for (int i = 0; i < drumSet.Count; i++)
            {
                drumSet[i] -= hitPower;
                if (drumSet[i] <= 0)
                {
                    if (savings - copyDrumset[i] * 3 > 0)
                    {
                        savings -= copyDrumset[i] * 3;
                        drumSet[i] = copyDrumset[i];
                    }
                    else
                    {
                        drumSet.RemoveAt(i);
                        copyDrumset.RemoveAt(i);
                        i--;
                    }
                }

            }
        }
    }
}
