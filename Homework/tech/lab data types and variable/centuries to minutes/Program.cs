using System;

namespace centuries_to_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte centuries = sbyte.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = " +
                $"{years} years = " +
                $"{days} days = " +
                $"{hours} hours = " +
                $"{minutes} minutes");

            
        }
    }
}
