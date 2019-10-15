using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //not working!!!!!!!!!!!!
            Dictionary<string, HashSet<string>> vloggerFollowers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> vloggersFollows = new Dictionary<string, int>();

            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = inputLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name1 = tokens[0];
                string command = tokens[1];

                if (command == "joined")
                {
                    if (!vloggerFollowers.ContainsKey(name1) && !vloggersFollows.ContainsKey(name1))
                    {
                        vloggerFollowers[name1] = new HashSet<string>();
                        vloggersFollows[name1] = 0;
                    }
                }
                else if (command == "followed")
                {
                    string name2 = tokens[2];
                    if (vloggerFollowers.ContainsKey(name1) && vloggerFollowers.ContainsKey(name2))
                    {
                        if (name1 != name2)
                        {
                            vloggerFollowers[name2].Add(name1);
                            vloggersFollows[name1]++;
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");

            int maxFollowers = 0;
            List<string> namesWithMostFollors = new List<string>();
            foreach (var vlogger in vloggerFollowers)
            {
                if(vlogger.Value.Count>=maxFollowers)
                {
                    namesWithMostFollors.Add(vlogger.Key);
                }
            }
            string bestVlogger = string.Empty;
            int minFollows = int.MaxValue;
            for (int i = 0; i < namesWithMostFollors.Count; i++)
            {
                if(vloggersFollows[namesWithMostFollors[i]]<minFollows)
                {
                    minFollows = vloggersFollows[namesWithMostFollors[i]];
                    bestVlogger = namesWithMostFollors[i];
                }
            }
            Console.WriteLine($"1. {bestVlogger} : {vloggerFollowers.Values.Count} followers, {vloggersFollows[bestVlogger]} following");
            foreach (var name in vloggerFollowers[bestVlogger].OrderBy(x=>x))
            {
                Console.WriteLine($"* {name}");
            }
            vloggerFollowers.Remove(bestVlogger);
            vloggersFollows.Remove(bestVlogger);
            foreach (var vlogger in vloggerFollowers.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine();
            }
          //foreach (var vlogger in vloggerFollowers.OrderBy(x=>x.Value.Count))
          //{
          //    count++;
          //    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggersFollows[vlogger.Key]} following");
          //    foreach (var name in vlogger.Value.OrderBy(x=>x))
          //    {
          //        Console.WriteLine($"* {name}");
          //    }
          //}
        }
    }
}
