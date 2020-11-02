using System;

namespace contact_name
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimer = Console.ReadLine();
            Console.WriteLine(firstName+delimer+secondName);
        }
    }
}
