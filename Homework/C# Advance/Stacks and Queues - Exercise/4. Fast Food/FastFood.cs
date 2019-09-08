using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4.Fast_Food
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] quantityOrder = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> orderQueue = new Queue<int>(quantityOrder);

            Console.WriteLine(orderQueue.Max());

            while (orderQueue.Count>0)
            {
                int order = orderQueue.Peek();
                if (quantityFood-order >= 0)
                {
                    quantityFood -= orderQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            
            if(orderQueue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ',orderQueue)}");
            }
        }
    }
}
