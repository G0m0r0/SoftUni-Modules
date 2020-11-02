using System;

namespace town_info
{
    class Program
    {
        static void Main(string[] args)
        {
            string cityName = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            ushort area = ushort.Parse(Console.ReadLine());
            Console.WriteLine($"Town {cityName} has population of {population} and area {area} square km.");
        }
    }
}
