using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Spaceship_Crafting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] chemicalLiquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueLiquids = new Queue<int>(chemicalLiquids);

            int[] physicalItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackItems = new Stack<int>(physicalItems);

            var dictionaryItems = new Dictionary<int, int>
            {
                {25, 0},
                {50,0 },
                {75,0},
                {100,0 }
            };


            while (queueLiquids.Count > 0 && stackItems.Count > 0)
            {
                int liquid = queueLiquids.Dequeue();
                int item = stackItems.Pop();
                int newItem = liquid + item;

                if (dictionaryItems.ContainsKey(newItem))
                {
                    dictionaryItems[newItem]++;
                }
                else
                {
                    item += 3;
                    stackItems.Push(item);
                }
            }
            bool success = true;
            foreach (var kvp in dictionaryItems)
            {
                if (kvp.Value == 0)
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueLiquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackItems.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {dictionaryItems[50]}");
            Console.WriteLine($"Carbon fiber: {dictionaryItems[100]}");
            Console.WriteLine($"Glass: {dictionaryItems[25]}");
            Console.WriteLine($"Lithium: {dictionaryItems[75]}");
        }
    }
}
