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
                StringBuilder text = new StringBuilder();
                text.Append(Console.ReadLine());

                int KeyTimes = 0;
                DecryptionKey(text, ref KeyTimes);

                LowerWithKeyValue(text, KeyTimes);

                //
                var populationRegex = Regex.Matches(text.ToString(), @"(?<=:)[0-9]+(?![0-9])");
                var soldiersRegex = Regex.Matches(text.ToString(), @"(?<=->)[0-9]+(?![0-9])");
                if (populationRegex.Count == 0 || soldiersRegex.Count == 0)
                    continue;
                //
                //
                var attackOrDestroy = Regex.Matches(text.ToString(), @"(?<=!)[D|A](?=!)");
                if (attackOrDestroy.Count == 0)
                    continue;
                //
                //
                var planet = Regex.Matches(text.ToString(), @"(?<=@)[A-za-z]+(?![A-Z])");
                if (planet.Count == 0)
                    continue;
                //
                if (string.Join("", attackOrDestroy) == "A")
                    planets["Attacked"].Add(string.Join("", planet));
                if (string.Join("", attackOrDestroy) == "D")
                    planets["Destroyed"].Add(string.Join("", planet));
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

        private static void LowerWithKeyValue(StringBuilder text, int keyTimes)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (char)(Convert.ToChar(text[i]) - keyTimes);
            }
        }

        private static void DecryptionKey(StringBuilder text, ref int keyTimes)
        {
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
        }
    }
}
