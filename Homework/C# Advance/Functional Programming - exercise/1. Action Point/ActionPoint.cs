using System;
using System.Linq;

namespace _1._Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string[]> print = items => Console.WriteLine(string.Join(Environment.NewLine,items));

            print(inputLine);
        }
    }
}
