using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueNumbers = new Queue<int>(input.Length);

            foreach (var number in input)
            {
                queueNumbers.Enqueue(number);
            }

            List<int> listEven = new List<int>(input.Length);
            foreach (var number in queueNumbers.Where(x => x % 2 == 0))
            {
                //or with for
                listEven.Add(number);
            }

            Console.WriteLine(string.Join(", ",listEven));
        }
    }
}
