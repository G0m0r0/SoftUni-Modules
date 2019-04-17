using System;
using System.Text.RegularExpressions;

namespace extract_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            var filteredPath = Regex.Matches(path, @"[^\\]*[.][a-z]{1,}");
            string[] nameExtention = string.Join("", filteredPath).Split('.');
            Console.WriteLine($"File name: {nameExtention[0]}");
            Console.WriteLine($"File extension: {nameExtention[1]}");
        }
    }
}
