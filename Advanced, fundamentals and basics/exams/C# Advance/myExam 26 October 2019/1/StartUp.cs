using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] male = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x > 0).ToArray();
            Stack<int> maleStack = new Stack<int>(male);

            int[] female = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x > 0).ToArray();
            Queue<int> femaleQueue = new Queue<int>(female);

            int countMatches = 0;
            while (true)
            {
                if (maleStack.Count == 0 || femaleQueue.Count == 0)
                {
                    break;
                }

                int man = maleStack.Pop();
                int woman = femaleQueue.Dequeue();

                if (man % 25 == 0 && woman % 25 == 0)
                {
                    if (maleStack.Count > 0)
                    {
                        man=maleStack.Pop();
                    }
                    else
                    {
                        woman=femaleQueue.Dequeue();
                        break;
                    }

                    if (femaleQueue.Count > 0)
                    {
                        woman=femaleQueue.Dequeue();
                    }
                    else
                    {
                        man=maleStack.Pop();
                        break;
                    }

                    continue;
                }

                else if (man % 25 == 0)
                {
                    if (maleStack.Count > 0)
                    {
                        man=maleStack.Pop();
                    }
                    else
                    {
                        femaleQueue.Enqueue(woman);
                        break;
                    }
                    femaleQueue.Enqueue(woman);
                    continue;
                }

                else if (woman % 25 == 0)
                {
                    if (femaleQueue.Count > 0)
                    {
                        woman=femaleQueue.Dequeue();
                    }
                    else
                    {
                        maleStack.Push(man);
                        break;
                    }
                    maleStack.Push(man);
                    continue;
                }

                if (man == woman)
                {
                    countMatches++;
                }
                else
                {
                    if (man - 2 > 0)
                    {
                        maleStack.Push(man - 2);
                    }
                }
            }

            Console.WriteLine($"Matches: {countMatches}");
            if (maleStack.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", maleStack)}");
            }

            if (femaleQueue.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", femaleQueue)}");
            }
        }
    }
}