using System;
using System.Text.RegularExpressions;

namespace regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string text= "Augusta Ada King, Countess of Lovelace (née Byron; 10 December 1815 – 27 November 1852) was an English mathematician and writer, chiefly known for her work on Charles Babbage's proposed mechanical general-purpose computer, the Analytical Engine. She was the first to recognise that the machine had applications beyond pure calculation, and published the first algorithm intended to be carried out by such a machine. As a result, she is sometimes regarded as the first to recognise the full potential of a and one of the first computer programmers.[2][3][4]";
            if (Regex.IsMatch(text, @""))
            {

            }

            var matches = Regex.Matches(text, @"([A-Z])([a-z]*)");
            // var matches = Regex.Matches(text, @"[A-Z][a-z]{2}"); //all words witg capital letter followed by 2 small
            // var matches = Regex.Matches(text, @"[0-9]{4}"); //output all numbers with 4numbers
            foreach (Match match in matches)
            {
                //Console.WriteLine(match.Value);
                Console.WriteLine(match.Groups[1]+" -> "+match.Groups[2]);
                //group[0] is all the text
            }

            string replacedString = Regex.Replace(text, @"", "_");
        }
    }
}
