using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split().ToArray();
            Console.WriteLine(command.Length);
        }
    }
}
