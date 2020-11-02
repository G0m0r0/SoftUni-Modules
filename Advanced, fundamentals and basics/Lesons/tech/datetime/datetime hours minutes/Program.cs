using System;

namespace datetime_hours_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(2019, 01, 22, hours, minutes, 00);
            date = date.AddMinutes(30);

            if (date.Minute >= 1 && date.Minute <= 9)
            {
                Console.WriteLine(date.Hour + ":0" + date.Minute);
            }
            else
            {
                Console.WriteLine(date.Hour + ":" + date.Minute);
            }
        }
    }
}
