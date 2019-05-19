using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3.Maximum_and_Minimum_Element
{
    class MinMaxValue
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());

            Stack<int> numberStack = new Stack<int>(numOfQueries);

            for (int i = 0; i < numOfQueries; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (commands[0])
                {
                    case 1:
                        numberStack.Push(commands[1]);
                        break;
                    case 2:
                        if (numberStack.Count > 0)
                            numberStack.Pop();
                        break;
                    case 3:
                        if (numberStack.Count > 0)
                            Console.WriteLine(numberStack.Max());
                        break;
                    case 4:
                        if (numberStack.Count > 0)
                            Console.WriteLine(numberStack.Min());
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numberStack));
        }
    }
}
