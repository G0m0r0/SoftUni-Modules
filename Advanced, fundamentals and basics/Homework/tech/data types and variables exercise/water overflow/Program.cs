using System;

namespace water_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte timesPoured = byte.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;
            while(timesPoured>counter)
            {
                counter++;
                int OnePour = int.Parse(Console.ReadLine());
                if (sum + OnePour > 255) Console.WriteLine("Insufficient capacity!");
                else sum += OnePour;
            }
            Console.WriteLine(sum);

        }
    }
}
