using System;
using System.Collections;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> namesQueue = new Queue<string>();

            string name = string.Empty;
            while ((name=Console.ReadLine())!="End")
            {
                if(name=="Paid")
                {
                    foreach (var person in namesQueue)
                    {
                        Console.WriteLine(person);
                    }
                    namesQueue.Clear();
                    continue;
                }
                namesQueue.Enqueue(name);
            }
            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
