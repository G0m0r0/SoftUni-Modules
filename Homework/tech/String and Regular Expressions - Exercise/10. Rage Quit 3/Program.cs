using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.Rage_Quit_3
{
    class Program
    {

        static void Main(string[] args)
        {

            string input = Console.ReadLine().ToUpper();

            Regex regex = new Regex(@"(([^\d]+)(\d+))");
            var filteredInput = regex.Matches(input);

            List<char> listChar = new List<char>();
            StringBuilder ragexMessage = new StringBuilder();
            foreach (Match match in filteredInput)
            {
                int numOfTimes = int.Parse(match.Groups[3].Value);
                if (numOfTimes == 0)
                    continue;
                string message = match.Groups[2].Value;
                for (int i = 0; i < message.Length; i++)
                {
                    if (!listChar.Contains(message[i]))
                        listChar.Add(message[i]);
                }
                for (int i = 0; i < numOfTimes; i++)
                {
                    ragexMessage.Append(message);
                }
            }

            Console.WriteLine($"Unique symbols used: {listChar.Count}");
            Console.WriteLine(ragexMessage);
        }
    }
}
