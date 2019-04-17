using System;

namespace elevator
{
    class Program
    {
        static void Main()
        {
            int person = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            if (capacity >= person) Console.WriteLine(1);
            else Console.WriteLine(Math.Ceiling((double)person/capacity));
        }
    }
}
