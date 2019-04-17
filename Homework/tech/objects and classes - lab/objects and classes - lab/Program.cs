using System;
using System.Globalization;
using System.Linq;

namespace objects_and_classes___lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();
            var exactDate = DateTime.ParseExact(date,"d-M-yyyy" , CultureInfo.InvariantCulture);           
            Console.WriteLine(exactDate.DayOfWeek);
        }
    }
}
