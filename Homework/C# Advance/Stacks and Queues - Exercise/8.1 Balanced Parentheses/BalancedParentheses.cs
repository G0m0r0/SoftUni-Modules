using System;
using System.Collections.Generic;

namespace _8._1_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> parenthesesDictionary = new Dictionary<char, char>
            {
                {'(',')' },
                {'{', '}'},
                {'[',']' }
            };

            Stack<char> openingParentheses = new Stack<char>();

            string parentheses = Console.ReadLine();

            if(parentheses.Length%2!=0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < parentheses.Length; i++)
            {
                if(parentheses[i]=='('||parentheses[i]=='{'||parentheses[i]=='[')
                {
                    openingParentheses.Push(parentheses[i]);
                }
                else if(openingParentheses.Count==0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    char lastParentheses = openingParentheses.Pop();
                    char expectedClosingBrackets = parenthesesDictionary[lastParentheses];
                    if(parentheses[i]!=expectedClosingBrackets)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if(openingParentheses.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
