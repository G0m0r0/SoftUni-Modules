using System;
using System.Collections.Generic;
using System.Linq;

namespace judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPoints = new Dictionary<string, int>();
            var contestUser = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] token = input.Split(" -> ");
                string username = token[0];
                string contest = token[1];
                int points = int.Parse(token[2]);

                if (!contestUser.ContainsKey(contest))
                {
                    contestUser[contest] = new List<string>();
                    if (!userPoints.ContainsKey(username))
                    {
                        userPoints[username] = 0;
                    }
                }
                else
                {
                    if (!userPoints.ContainsKey(username))
                    {
                        userPoints[username] = 0;
                    }
                }

                contestUser[contest].Add(username);
                if (userPoints[username] < points)
                {
                    userPoints[username] = points;
                }
            }
            foreach (var kvp in contestUser)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                int number = 0;
                foreach (var item in kvp.Value)
                {
                    number++;
                    Console.WriteLine($"{number}. {item} <::> {userPoints[item]}");
                }
            }
            Console.WriteLine("Individual standings:");
            int br = 0;
            foreach (var kvp in userPoints)
            {
                br++;
                Console.WriteLine($"{br}. {kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
