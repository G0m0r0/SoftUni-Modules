using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _9.Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int countMesseges = int.Parse(Console.ReadLine());
            var planets = new Dictionary<string, List<string>>();
            planets["Attacked"] = new List<string>();
            planets["Destroyed"] = new List<string>();

            for (int i = 0; i < countMesseges; i++)
            {
                string action = Console.ReadLine();
                int KeyTimes = DecryptionKey(action);
                action = LowerWithKeyValue(action, KeyTimes);

                Regex filter = new Regex(@"@(?<name>[A-Za-z]+)([^@:!\->]*):(?<population>[0-9]+)([^@:!\->]*)!(?<type>(A|D))!([^@:!\->]*)->(?<count>[0-9]+)");
                var filteredInput = filter.Matches(action);
                foreach (Match item in filteredInput)
                {
                    string planeName = item.Groups["name"].Value;
                    int population = int.Parse(item.Groups["population"].Value);
                    string attackType = item.Groups["type"].Value;
                    int soldierCount = int.Parse(item.Groups["count"].Value);

                    if (population >= 0 && soldierCount >= 0)
                        if (attackType == "A")
                        {
                            planets["Attacked"].Add(planeName);
                        }
                        else if (attackType == "D")
                        {
                            planets["Destroyed"].Add(planeName);
                        }
                }
            }

            foreach (var kvp in planets)
            {
                Console.WriteLine($"{kvp.Key} planets: {kvp.Value.Count}");
                if (kvp.Value.Count > 0)
                {
                    foreach (var item in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"-> {item}");
                    }
                }
            }
        }

        private static string LowerWithKeyValue(string text, int keyTimes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text);
            for (int i = 0; i < text.Length; i++)
            {
                sb[i] = (char)(Convert.ToChar(text[i]) - keyTimes);
            }

            return sb.ToString();
        }

        private static int DecryptionKey(string text)
        {
            int keyTimes = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i].ToString().ToLower())
                {
                    case "s":
                    case "t":
                    case "a":
                    case "r":
                        keyTimes++;
                        break;
                }
            }
            return keyTimes;
        }
    }
}
