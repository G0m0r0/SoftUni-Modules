using System;
using System.Collections.Generic;
using System.Linq;

namespace House_party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());
            List<string> guesstList = new List<string>();

            for (int i = 0; i < numberCommands; i++)
            {
                string[] goingORnot = Console.ReadLine().Split(" ").ToArray();

                if (goingORnot.Length == 3)
                {
                    if (guesstList.Contains(goingORnot[0]))
                        Console.WriteLine($"{goingORnot[0]} is already in the list!");
                    else
                        guesstList.Add(goingORnot[0]);
                }
                else
                {
                    if (guesstList.Contains(goingORnot[0]))
                        guesstList.Remove(goingORnot[0]);
                    else
                        Console.WriteLine($"{goingORnot[0]} is not in the list!");
                }
            }
            Console.WriteLine(string.Join("\n",guesstList));
        }
    }
}
