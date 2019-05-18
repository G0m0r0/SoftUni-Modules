using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_calculatorr
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(' ');
            Stack<string> stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        Console.WriteLine($"{first} + { second} = { first + second} ");
                        break;
                    case "-":
                        stack.Push((first - second).ToString());
                        Console.WriteLine($"{first} - {second} = {first - second}");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
