using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues___Exercise
{
    class BasicOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = input[0];  //elements to push
            int S = input[1];  //elements to pop
            int X = input[2];  //elements to peek

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackNumbers = new Stack<int>(numbers.Length);

            for (int i = 0; i < N; i++)
            {
                stackNumbers.Push(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stackNumbers.Count > 0)
                    Console.WriteLine(stackNumbers.Min());
                else
                    Console.WriteLine("0");
            }
        }
    }
}
