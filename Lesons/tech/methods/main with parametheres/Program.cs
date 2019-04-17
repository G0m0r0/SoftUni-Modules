using System;

namespace main_with_parametheres
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            foreach (var arg in args)
            {
                Console.WriteLine(args);
            }
            //args have null value!!!
        }
    }
}
