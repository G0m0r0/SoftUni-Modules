using System;

namespace timespawn
{
    class Program
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            TimeSpan time = new TimeSpan(hours, minutes + 30, 0);
            Console.WriteLine($"{time:h\\:mm}");
        }
    }
}
