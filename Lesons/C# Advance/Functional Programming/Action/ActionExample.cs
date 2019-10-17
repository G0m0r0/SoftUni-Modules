using System;

namespace ActionExample
{
    class ActionExample
    {
        static void Main(string[] args)
        {
            Action<string> method = msg => Console.WriteLine(msg);
            Action method2 = () =>
            {
                Console.WriteLine("Hello");
                Console.WriteLine("Hello");
                Console.WriteLine("Hello");
                Console.WriteLine("Hello");
            };
            method2();
        }
    }
}
