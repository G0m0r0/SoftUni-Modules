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
                string tokens = Console.ReadLine();
                string expansion = tokens.Remove(0, 1);
                expansion = expansion.TrimStart();
                switch (tokens[0])
                {
                    case '1':
                        text.Append(expansion);
                        textStack.Push(text.ToString());
                        break;
                    case '2':
                        if (int.Parse(expansion) <= text.Length)
                            text.Remove(text.Length - int.Parse(expansion), int.Parse(expansion));
                        if (text.Length == 0)
                        {
                            textStack.Push(null);
                        }
                        else
                        {
                            textStack.Push(text.ToString());
                        }
                        break;
                    case '3':
                        if (text.Length > 0 && int.Parse(expansion) <= text.Length)
                            Console.WriteLine(text[int.Parse(expansion) - 1]);
                        break;
                    case '4':
                        text.Clear();
                        if (textStack.Count > 0)
                        {
                            textStack.Pop();
                            if (textStack.Count > 0)
                                text.Append(textStack.Peek());
                        }
                        break;
                }
                //Console.WriteLine("text- " + text);
               // Console.WriteLine("textStack- " + string.Join(" ", textStack));
            }
        }
    }
}
