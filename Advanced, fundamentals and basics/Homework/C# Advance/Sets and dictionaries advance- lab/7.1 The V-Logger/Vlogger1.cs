using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._1_The_V_Logger
{
    class Vlogger1
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] inputInfo = command.Split();

                if (inputInfo[1] == "joined")
                {
                    string username = inputInfo[0];
                    if (!vlogger.ContainsKey(username))
                    {
                        vlogger[username] = new Dictionary<string, HashSet<string>>();
                        vlogger[username]["followed"] = new HashSet<string>();
                        vlogger[username]["followers"] = new HashSet<string>();
                    }
                }
                else if (inputInfo[1] == "followed")
                {
                    string mainUser = inputInfo[2];
                    string follower = inputInfo[0];

                    if (mainUser != follower)
                        if (vlogger.ContainsKey(mainUser) && vlogger.ContainsKey(follower))
                        {
                            vlogger[mainUser]["followers"].Add(follower);
                            vlogger[follower]["followed"].Add(mainUser);
                        }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");
           // var sortedVlogers = vlogger
           //     .OrderByDescending(x => x.Value["followers"].Count)
           //     .ThenBy(x => x.Value["followed"].Count)
           //     .ToDictionary(k => k.Key, v => v.Value);
            int counter = 1;
            foreach (var (vlog,collectionOfPeople) in vlogger
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["followed"].Count))
            {
                Console.WriteLine($"{counter}. {vlog} : {collectionOfPeople["followers"].Count} followers, {collectionOfPeople["followed"].Count} following");
                if(counter==1)
                {
                    foreach (var name in collectionOfPeople["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                counter++;
            }
        }
    }
}
