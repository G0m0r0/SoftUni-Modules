using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomParsingFunction
{
    static class CustomParsingFunction
    {
        static void Main(string[] args)
        {
            var inputElements = Console.ReadLine().Split(", ").Select(Parse);
            Console.WriteLine(string.Join(' ',inputElements));
            Console.WriteLine(inputElements.Count());
            Console.WriteLine(inputElements.Sum());
        }
        static int Parse(string str)
        {
            int number = 0;
            // "1233"=>(int)12344
            foreach (var ch in str)
            {
                number *= 10;
                number += ch - '0';
                //(int)'1' -> 49-48
                //'2'
            }
            return number;
        }
    }
}
