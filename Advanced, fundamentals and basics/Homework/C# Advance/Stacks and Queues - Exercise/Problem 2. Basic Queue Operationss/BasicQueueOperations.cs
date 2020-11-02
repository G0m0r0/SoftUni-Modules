using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Basic_Queue_Operationss
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int enqueue = input[0];
            int dequeue = input[1];
            int searchNum = input[2];

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < enqueue; i++)
            {
                numbers.Enqueue(inputValues[i]);
            }

            for (int i = 0; i < dequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else if (numbers.Contains(searchNum))
            {
                Console.WriteLine("true");
            }
            else
            {
                    Console.WriteLine(numbers.Min());
            }
        }
    }
}
