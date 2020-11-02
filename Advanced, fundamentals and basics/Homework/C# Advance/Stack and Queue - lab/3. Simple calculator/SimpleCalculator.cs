using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3.Simple_calculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            //we can add colletions to stack
            Stack<string> stackOfNumbers = new Stack<string>(input.Reverse());

            while (stackOfNumbers.Count > 1)
            {
                int firstNum = int.Parse(stackOfNumbers.Pop());
                char operation = char.Parse(stackOfNumbers.Pop());
                int secondNum = int.Parse(stackOfNumbers.Pop());

                switch (operation)
                {
                    case '+':
                        stackOfNumbers.Push((firstNum + secondNum).ToString());
                        break;
                    case '-':
                        stackOfNumbers.Push((firstNum - secondNum).ToString());
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in stackOfNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
