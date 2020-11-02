using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            //Dictionary<contest,password>
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();
            //Dictionary<username<contest,points>>
            Dictionary<string, Dictionary<string, int>> usernamePoints = new Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = tokens[0];
                string password = tokens[1];
                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword[contest] = password;
                }
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contestPassword.ContainsKey(contest))
                {
                    continue;
                }
                if (contestPassword[contest] != password)
                {
                    continue;
                }
                if (!usernamePoints.ContainsKey(username))
                {
                    usernamePoints[username] = new Dictionary<string, int>();
                }
                if (!usernamePoints[username].ContainsKey(contest))
                {
                    usernamePoints[username][contest] = points;
                }
                else
                {
                    if (usernamePoints[username][contest] < points)
                    {
                        usernamePoints[username][contest] = points;
                    }
                }
            } 

            int maxSum = int.MinValue;
            //string bestUser = string.Empty;
            // foreach (var user in usernamePoints)
            // {
            //     int sum = 0;
            //     foreach (var contests in user.Value)
            //     {
            //         sum += contests.Value;
            //     }
            //     if(maxSum<sum)
            //     {
            //         bestUser = user.Key;
            //         maxSum = sum;
            //     }
            // }
            var bestUser = usernamePoints.OrderByDescending(x => x.Value.Sum(x => x.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value.Sum(x=>x.Value)} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in usernamePoints.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
