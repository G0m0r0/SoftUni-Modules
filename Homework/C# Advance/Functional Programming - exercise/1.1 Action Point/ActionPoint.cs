using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> print = item => Console.WriteLine(item);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);


        }
    }
}
