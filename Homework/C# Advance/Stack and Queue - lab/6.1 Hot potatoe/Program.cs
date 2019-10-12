using System;
using System.Collections;
using System.Collections.Generic;

namespace _6._1_Hot_potatoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));
            int passes = int.Parse(Console.ReadLine());

            while (people.Count>1)
            {
                for (int i = 1; i < passes; i++)
                {                   
                    people.Enqueue(people.Dequeue());
                }
                Console.WriteLine($"Removed {people.Peek()}");
                people.Dequeue();
            }

            Console.WriteLine($"Last is {people.Dequeue()}");
        }
    }
}
