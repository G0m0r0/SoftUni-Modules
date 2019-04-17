using System;
using System.Collections.Generic;
using System.Linq;

namespace company_users
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, List<string>>();

            string[] company = Console.ReadLine().Split(" -> ");
            while (company[0] != "End")
            {

                if (!users.ContainsKey(company[0]))
                {
                    users[company[0]] = new List<string> { company[1] };
                }
                else
                {
                    if (!users[company[0]].Contains(company[1]))
                        users[company[0]].Add(company[1]);
                }
                company = Console.ReadLine().Split(" -> ");
            }

            foreach (var kvp in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
