using System;
using System.Text.RegularExpressions;

namespace _2.Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            string pattern = $"([{ch1}-{ch2}])+";
            Regex filter = new Regex(@pattern);

                 int sumASCII = 0;

                //string numberASCII =filter.Match(input).Groups[1].Value;

                for (int i = 0; i < numberASCII.Length; i++)
                {
                    sumASCII += numberASCII[i];
                }                    
            Console.WriteLine(sumASCII);
        }
    }
}
