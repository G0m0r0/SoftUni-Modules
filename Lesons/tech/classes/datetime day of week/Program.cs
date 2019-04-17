using System;
using System.Globalization;

namespace datetime_day_of_week
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //18-04-2016
            DateTime datetime = DateTime.ParseExact(input,"dd-MM-yyyy",CultureInfo.InvariantCulture);
            // DateTime datime = DateTime.ParseExact(input,"8-04-2016");
            Console.WriteLine(datetime.DayOfWeek);
        }
    }
}
