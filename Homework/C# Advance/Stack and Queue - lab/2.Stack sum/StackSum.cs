using System;
using System.Collections;
using System.Collections.Generic;

namespace _2.Stack_sum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<int> stackNumbers = new Stack<int>();

            foreach (var number in input)
            {
                stackNumbers.Push(int.Parse(number));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] token = command.Split();
                string action = token[0];            
                switch (action)
                {
                    case "add":
                        int firstNum =int.Parse( token[1]);
                        int secondNum = int.Parse(token[2]);
                        stackNumbers.Push(firstNum);
                        stackNumbers.Push(secondNum);
                        break;
                    case "remove":
                        int numbersToRemove = int.Parse(token[1]);
                        if(stackNumbers.Count>numbersToRemove)
                        {
                            for (int i = 0; i < numbersToRemove; i++)
                            {
                                stackNumbers.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            int sumOfRemainingElemnets = 0;
            foreach (var num in stackNumbers)
            {
                sumOfRemainingElemnets += num;
            }

            Console.WriteLine($"Sum: {sumOfRemainingElemnets}");
        }
    }
}
