using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var bandDictionary = new Dictionary<string, List<string>>();
            var bandPlayTime = new Dictionary<string, int>();

            int totalTime = 0;
            while (command != "start of concert")
            {
                string[] tokens = command.Split(new char[] { ',', ';', }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (tokens[0].Trim())
                {
                    case "Add":
                        AddBandsAndMembers(bandDictionary, tokens);
                        break;
                    case "Play":
                        totalTime += int.Parse(tokens[2].Trim());
                        BandPlayTime(bandPlayTime, tokens[1].Trim(),int.Parse(tokens[2].Trim()),bandDictionary);
                        break;
                }

                command = Console.ReadLine();
            }
            string detailsOnBand = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var kvp in bandPlayTime.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine(detailsOnBand);
            foreach (var item in bandDictionary[detailsOnBand])
            {
                Console.WriteLine($"=>{item}");
            }

        }

        private static void BandPlayTime(Dictionary<string, int> bandPlayTime, string band, int time, Dictionary<string, List<string>> bandDictionary)
        {
            if(!bandPlayTime.ContainsKey(band))
            {
                bandPlayTime[band] = 0;
            }
                bandPlayTime[band] += time;
        }

        private static void AddBandsAndMembers(Dictionary<string, List<string>> bandDictionary, string[] tokens)
        {
            if (!bandDictionary.ContainsKey(tokens[1].Trim()))
            {
                bandDictionary[tokens[1].Trim()] = new List<string>();
            }
            for (int i = 2; i < tokens.Length; i++)
            {
                if (!bandDictionary[tokens[1].Trim()].Contains(tokens[i]))
                    bandDictionary[tokens[1].Trim()].Add(tokens[i]);
            }
        }
    }
}
