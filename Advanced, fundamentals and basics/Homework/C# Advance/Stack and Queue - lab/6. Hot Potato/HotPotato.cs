using System;
using System.Collections;
using System.Collections.Generic;

namespace _6.Hot_Potato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int numberOfTossing = int.Parse(Console.ReadLine());
            Queue<string> childrenQueue = new Queue<string>(input);

            while (childrenQueue.Count>1)
            {
                for(int i = 0; i < numberOfTossing-1; i++)
                {
                    childrenQueue.Enqueue(childrenQueue.Dequeue());
                }
                Console.WriteLine($"Removed {childrenQueue.Dequeue()}");
                //childrenQueue.Dequeue();
            }
            foreach (var name in childrenQueue)
            {
                Console.WriteLine($"Last is {name}");
            }
        }
    }
}
