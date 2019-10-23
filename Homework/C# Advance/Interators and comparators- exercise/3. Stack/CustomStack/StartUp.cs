using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                if(command.StartsWith("Push"))
                {
                    command = command.Remove(0, 5);
                    string[] tokens= command.Split(", ").ToArray();
                    myStack.Push(tokens);
                }
                else if(command=="Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
