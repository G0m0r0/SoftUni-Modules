using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int numOfOperation = int.Parse(Console.ReadLine());
            Stack<string> textStack = new Stack<string>();

            StringBuilder text = new StringBuilder();
            for (int i = 0; i < numOfOperation; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (tokens[0])
                {
                    case "1":
                        text.Append(tokens[1]);
                        textStack.Push(text.ToString());
                        break;
                    case "2":
                        text.Remove(text.Length - int.Parse(tokens[1]), text.Length);
                        textStack.Push(text.ToString());
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(tokens[1])-1]);
                        break;
                    case "4":
                        if(text.ToString()==textStack.Peek())
                        {
                            textStack.Pop();
                        }
                        text.Remove(0,text.Length);
                        text.Append(textStack.Pop());
                        break;
                }
            }
        }
    }
}
