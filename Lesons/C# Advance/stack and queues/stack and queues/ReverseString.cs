using System;
using System.Collections;
using System.Collections.Generic;

namespace stack_and_queues
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            Stack<char> stringReverse = new Stack<char>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                stringReverse.Push(ch);
            }

            //with pop we dont have anything in the memory!!!!
            // while (stringReverse.Count>0)
            // {
            //     Console.Write(stringReverse.Pop());
            // }
            foreach (var item in stringReverse)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.WriteLine(stringReverse.Count);

            //program crash if we try to pop 0
            while (stringReverse.Count >=0)
            {
                char element;

                if(stringReverse.TryPop(out element))
                {
                    Console.Write(element);
                }
                else
                {
                    //to break infinit looping
                    break;
                }
            }
            Console.WriteLine();

            Console.WriteLine(stringReverse.Count);
            
        }
    }
}
