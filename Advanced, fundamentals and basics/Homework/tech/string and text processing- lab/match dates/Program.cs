using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace match_dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();
            var filteredDates = Regex.Matches(dates, @"\b(?<day>\d{2})(?<separator>[-.\/])(?<month>[A-z][a-z]{2})\k<separator>(?<year>\d{4})\b");


            foreach (var date in filteredDates)
            {
                List<string> strDate = date.ToString().Split(new char[] {'/','-','.' }).ToList();
                Console.WriteLine($"Day: {strDate[0]}, Month: {strDate[1]}, Year: {strDate[2]}");
            }
        }
    }
}
