using System;
using System.Collections.Generic;

namespace Queue
{
    class Queuecs
    {
        static void Main(string[] args)
        {
            //hot pottato problem
            var children = Console.ReadLine().Split();
            var number = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);
            while (queue.Count!=1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Remove {queue.Dequeue()}");
            }
            Console.WriteLine($"Last in {queue.Dequeue()}");
        }
    }
}
