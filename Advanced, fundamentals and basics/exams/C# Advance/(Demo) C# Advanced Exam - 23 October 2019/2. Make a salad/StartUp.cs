using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Make_a_salad
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] vegetables = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();
            Queue<string> queueVegetables = new Queue<string>(vegetables);

            int[] calories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackCalories = new Stack<int>(calories);

            Dictionary<string, int> vegetableCalories = new Dictionary<string, int>()
            {
                {"tomato",80 },
                {"carrot",136 },
                {"lettuce",109 },
                {"potato",215 }
            };

            List<int> preparedSalads = new List<int>();
             while (stackCalories.Count > 0 && queueVegetables.Count > 0)
             {
                 string vegetable = queueVegetables.Dequeue();
                 int saladCalories = stackCalories.Peek();
                 while (saladCalories >= 0)
                 {
                     //substract vegetable
                     saladCalories -= vegetableCalories[vegetable];
                     if (saladCalories <= 0)
                     {
                         preparedSalads.Add(stackCalories.Pop());
                         // if (stackCalories.Count > 0)
                         // {
                         //     saladCalories = stackCalories.Peek();
                         // }
                         // else
                         // {
                         //     break;
                         // }     
                         break;
                     }
                     else
                     {
                         if (queueVegetables.Count > 0)
                         {
                             vegetable = queueVegetables.Dequeue();
                         }
                         else
                         {
                             preparedSalads.Add(stackCalories.Pop());
                             break;
                         }
                     }
                 }
             }
            Console.WriteLine(string.Join(" ", preparedSalads));
            if (stackCalories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", stackCalories));
            }
            else if (queueVegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", queueVegetables));
            }

        }
    }
}
