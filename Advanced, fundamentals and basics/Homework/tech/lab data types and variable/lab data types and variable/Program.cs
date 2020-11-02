using System;

namespace lab_data_types_and_variable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"{((decimal)num/1000):f2}");
        }
    }
}
