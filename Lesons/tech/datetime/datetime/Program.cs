using System;

namespace datetime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Time now "+now);
            Console.WriteLine("Last year " + now.AddYears(-1));
            Console.WriteLine("Next month "+now.AddMonths(+1));
            Console.WriteLine("Next week "+now.AddDays(7));
            Console.WriteLine("After 30 minutes will be "+now.AddMinutes(+30));

            string customDatetimeString = "03/24/2018"; //first moth
            DateTime customDatetime= DateTime.Parse(customDatetimeString);
            Console.WriteLine("Custom date time: "+customDatetime);
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            DateTime time = new DateTime(2008,1,1,a,b,1);
            Console.WriteLine(time.ToString("H:mm"));


        }
    }
}
