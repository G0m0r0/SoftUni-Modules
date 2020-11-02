using System;

namespace _05.Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int hoursInMinutes = hours * 60;
            int totalMinutes = hoursInMinutes + minutes + 15;

            TimeSpan result = TimeSpan.FromMinutes(totalMinutes);
            string stringResult = result.ToString("h':'mm");

            Console.WriteLine(stringResult);
        }
    }
}
