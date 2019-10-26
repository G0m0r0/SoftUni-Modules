using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1.Club_Party
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hallMaxCapacity = int.Parse(Console.ReadLine());
            string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> inputStack = new Stack<string>(inputLine);

            List<int> reservations = new List<int>();
            Queue<char> halls =new Queue<char>();

            int capacity = hallMaxCapacity;
            int num = 0;
            string element = inputStack.Peek();
            while (int.TryParse(element,out num))
            {
                inputStack.Pop();
                element = inputStack.Peek();
            }

            while (inputStack.Count > 0)
            {
                element = inputStack.Pop();
                if (int.TryParse(element, out num))
                {
                    if (capacity - num < 0)
                    {
                        if(halls.Count==0)
                        {
                            break;
                        }
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", reservations)}");
                        capacity = hallMaxCapacity-num;
                        reservations.Clear();
                        reservations.Add(num);
                    }
                    else
                    {
                        capacity -= num;
                        reservations.Add(num);
                    }
                }
                else
                {
                    halls.Enqueue(char.Parse(element));
                }
            }


        }
    }
}
