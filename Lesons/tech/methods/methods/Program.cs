using System;

namespace methods
{
    class Program
    {
        //we cant use var in methods
        static void Main(string[] args)
        {
        //its possible to change first and second value
        //like this (end: color start: string)
        http://test.com 
            for (int i = 0; i < 100; i++)
            {
                PrintYellow(i.ToString(), (ConsoleColor)(i % 16));
            }
            //sintax sugar
        }
        //if we set default values to parameters (string text="ivan")
        //there is no need of initialize it later in the main function

          
        static void PrintYellow(string textToPrint, ConsoleColor color)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(textToPrint);
            Console.ResetColor();
        }
    }
}
