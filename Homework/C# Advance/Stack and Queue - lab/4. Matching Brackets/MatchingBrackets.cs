using System;
using System.Collections;
using System.Collections.Generic;

namespace _4.Matching_Brackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stackBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i]=='(')
                {
                    stackBrackets.Push(i);
                }
                else if(input[i]==')')
                {
                    int start = stackBrackets.Pop();
                    Console.WriteLine(input.Substring(start,i-start+1));
                }
            }
        }
    }
}
