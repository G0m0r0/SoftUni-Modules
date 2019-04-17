using System;

namespace pounds_to_dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            Console.WriteLine("{0:f3}",pounds* 1.31m);
        }
    }
}
