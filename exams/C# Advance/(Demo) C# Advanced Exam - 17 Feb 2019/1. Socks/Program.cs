using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] leftSocks = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rightSocks = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> leftStack = new Stack<int>(leftSocks);
            Queue<int> rightQueue = new Queue<int>(rightSocks);

            List<int> pairs = new List<int>();

            while (leftStack.Count>0&&rightQueue.Count>0)
            {
                int left = leftStack.Peek();
                int right = rightQueue.Peek();
                if (left > right)
                {
                    pairs.Add(left + right);
                    leftStack.Pop();
                    rightQueue.Dequeue();
                }
                else if(right>left)
                {
                    leftStack.Pop();
                }
                else
                {
                    rightQueue.Dequeue();
                    leftStack.Pop();
                    leftStack.Push(left + 1);
                }                        
            }
            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
