using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Balanced_Parenthesis
{
    class BalancedParenthasies
    {
        static void Main(string[] args)
        {
            char[] parentheses = Console.ReadLine().ToCharArray();
            Stack<char> openingParentheses = new Stack<char>();

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < parentheses.Length; i++)
            {
                switch (parentheses[i])
                {
                    case '(':
                    case '[':
                    case '{':
                        openingParentheses.Push(parentheses[i]);
                        break;
                    case ')':
                        MatchingClosingParentheses('(', openingParentheses);
                        break;
                    case ']':
                        MatchingClosingParentheses('[', openingParentheses);
                        break;
                    case '}':
                        MatchingClosingParentheses('{', openingParentheses);
                        break;
                }
            }
            if (openingParentheses.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static void MatchingClosingParentheses(char ch,Stack<char> openingParentheses)
        {
            if (openingParentheses.Count == 0)
            {
                Console.WriteLine("NO");
                return;
            }
            else if (openingParentheses.Pop() != ch)
            {
                Console.WriteLine("NO");
                return;
            }
        }

    }
}
