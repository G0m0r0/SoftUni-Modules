using System;
using System.Text.RegularExpressions;

namespace _8.Match_a_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbers = Console.ReadLine();
            var filteredPhoneNumbers = Regex.Matches(phoneNumbers, @"[+][3][5][9](?<separators>[\s-])[2]\k<separators>[0-9]{3}\k<separators>[0-9]{4}\b");

            Console.WriteLine(string.Join(", ",filteredPhoneNumbers));
        }
    }
}
