using System;

namespace func_example_2
{
    class FuncExample2
    {
        static void Main(string[] args)
        {
            //input list on int and output long
            //Func<int,int,int,long>
            //Func returns parameter

            //Action action //its possible to not have parameters
            //Doesnt have to return parameter
            Action<int> action = PrintToConsoleWithLines;
            action += PrintToConsole;
            //we can add more fuction with operator += like a list of function
            action += PrintToConsole;
            action += PrintToConsole;
            action += PrintToConsole;
            action += PrintToConsole;
            action(3);
            action(100);
        }
        static void PrintToConsoleWithLines(int x)
        {
            Console.WriteLine($"==================");
            Console.WriteLine($"PrintToConsoleWithLines {x}");
            Console.WriteLine($"==================");
        }
        static void PrintToConsole(int x)
        {
            Console.WriteLine($"PrintToConsole {x}");
        }
    }
}
