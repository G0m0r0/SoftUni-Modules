using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace My_project1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(([A-Za-z])([\d]+)([A-Za-z]))");
            var filteredInput = regex.Matches(input);
            double sum = 0;

            foreach (Match match in filteredInput)
            {
                char LeftLetter =char.Parse( match.Groups[2].Value);
                double number =double.Parse( match.Groups[3].Value);
                char RightLetter =char.Parse( match.Groups[4].Value);

                if(char.IsUpper(LeftLetter))
                {
                    number /= (LeftLetter - 64);
                }
                else
                {
                    number *= (LeftLetter - 96);
                }
                if(char.IsUpper(RightLetter))
                {
                    number -= (RightLetter - 64);
                }
                else
                {
                    number += (RightLetter - 96);
                }

                sum += number;
            }
            Console.WriteLine($"{(sum):f2}");
        }


    }
}
