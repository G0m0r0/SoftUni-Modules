using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.Song_Encryption_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            //we always put @
            string artisPattern = @"([A-Z][a-z ']*)";
            string songPattern = @"([A-Z ]*)";
            string keepPattern = @"[^' @]";

            string line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                string[] token = line.Split(":");
                string artist = token[0];
                string song = token[1];

                bool artistIsValid = Regex.IsMatch(artist, artisPattern);
                bool songIsValid = Regex.IsMatch(song, songPattern);

                if (!artistIsValid || !songIsValid)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (artistIsValid && songIsValid)
                {
                    Match artisMatch = Regex.Match(artist, artisPattern);
                    Match songMatch = Regex.Match(song, songPattern);

                    int lengh = artist.Length;
                    string text = $"{artisMatch.Groups[1].Value}@{songMatch.Groups[1].Value}";

                    StringBuilder sb = new StringBuilder();
                    foreach (var symbol in text)
                    {
                        char newSymbol = symbol;
                        bool isValidSymbol = Regex.IsMatch(newSymbol.ToString(), keepPattern);
                        if (isValidSymbol)
                        {
                            newSymbol = (char)(newSymbol + lengh);
                            if (symbol <= 90 && newSymbol > 90)
                            {
                                newSymbol -= (char)26;
                            }
                            else if (symbol <= 122 && newSymbol > 122)
                            {
                                newSymbol -= (char)26;
                            }
                        }
                        sb.Append(newSymbol);
                    }
                    Console.WriteLine("Successful encryption: {0}",sb);
                }
                line = Console.ReadLine();
            }
        }
    }
}
