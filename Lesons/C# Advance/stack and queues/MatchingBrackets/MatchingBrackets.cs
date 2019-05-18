using System;
using System.Collections;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";

            Stack<int> expressionFinder = new Stack<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    expressionFinder.Push(i);
                }
                else if (input[i] == ')')
                {
                    int start = expressionFinder.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }
        }
    }
}
