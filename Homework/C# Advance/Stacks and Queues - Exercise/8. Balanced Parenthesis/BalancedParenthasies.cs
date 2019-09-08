using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Balanced_Parenthesis
{
    class BalancedParenthasies
    {
        static void Main(string[] args)
        {
            char[] parenthesis = Console.ReadLine().ToCharArray();
            if(parenthesis.Length%2!=0)
            {
                Console.WriteLine("NO");
                return;
            }
            Stack<char> parenthesisStack = new Stack<char>(parenthesis.Length/2);

            for (int i = 0; i < parenthesis.Length/2; i++)
            {
                parenthesisStack.Push(parenthesis[i]);
            }

            for (int i = 0; i < parenthesis.Length/2; i++)
            {

            }
        }
    }
}
