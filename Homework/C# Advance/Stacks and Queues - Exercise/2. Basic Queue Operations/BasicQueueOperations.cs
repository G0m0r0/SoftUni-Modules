using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2.Basic_Queue_Operations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0]; //elements to enqueue
            int S = input[1]; //elements to dequeue
            int X = input[2]; //element to peek

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueNumbers = new Queue<int>(numbers.Length);

            for (int i = 0; i <N ; i++)
            {
                queueNumbers.Enqueue(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                queueNumbers.Dequeue();
            }

            if(queueNumbers.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(queueNumbers.Count>0)
                {
                    Console.WriteLine(queueNumbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
