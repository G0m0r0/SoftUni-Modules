using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_and_Queue___lab
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            //using last in, first out method- LIFO
            string input = Console.ReadLine();
            Stack<char> stringReverse = new Stack<char>();

            foreach (var ch in input)
            {
                stringReverse.Push(ch);
            }

            foreach (var item in stringReverse)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
