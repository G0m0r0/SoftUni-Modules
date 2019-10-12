using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12.__Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottleStack = new Stack<int>(bottles);
            Queue<int> cupsQueue = new Queue<int>(cups);

            int wastedLittersOfWater = 0;
            int singleBottle = 0;
            int SingleCup = 0;
            for (int i = 0; i < bottles.Length; i++)
            {
                if (cupsQueue.Count == 0)
                {
                    break;
                }
                singleBottle = bottleStack.Pop();
                if (SingleCup == 0)
                    SingleCup = cupsQueue.Peek();

                if (singleBottle >= SingleCup)
                {
                    wastedLittersOfWater += (singleBottle - SingleCup);
                    SingleCup = 0;
                    cupsQueue.Dequeue();
                }
                else
                {
                    SingleCup -= singleBottle;
                }
            }

            if (cupsQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottleStack)}");
            }
            if (bottleStack.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
            }
            //OR
           // Console.WriteLine(bottleStack.Count > 0
           //     ? $"Bottles: {string.Join(' ', bottleStack)}"
           //     : $"Cups: {string.Join(' ', cupsQueue)}");

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
