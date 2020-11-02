using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorAddRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(x => int.Parse(x));

            var stack = new Stack<int>(numbers);

            while (true)
            {
                var command = Console.ReadLine().ToLower().Trim();
                if(command.StartsWith("add"))
                {
                    var parts = command.Split(" ");
                    stack.Push(int.Parse(parts[1]));
                    stack.Push(int.Parse(parts[2]));
                }
                else if(command.StartsWith("remove"))
                {
                    var parts = command.Split(" ");
                    var itemsToRemove = int.Parse(parts[1]);
                    for (int i = 0; i < itemsToRemove; i++)
                    {
                        if(stack.Count>=0)
                        stack.Pop();
                    }
                }
                else if(command=="end")
                {

                }
            }
        }
    }
}
