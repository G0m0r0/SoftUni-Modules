using System;
using System.Collections.Generic;
using System.Linq;

namespace softuni_exam_results
{
    class Program
    {
        static void Main(string[] args)
        {
            var personResult = new Dictionary<string, int>();
            var submission = new Dictionary<string, int>();

            string[] command = Console.ReadLine().Split("-");
            while (command[0] != "exam finished")
            {
                if (command[1] == "banned")
                {
                    personResult.Remove(command[0]);
                }
                else if (!personResult.ContainsKey(command[0]))
                {
                    personResult[command[0]] = int.Parse(command[2]);
                    if (!submission.ContainsKey(command[1]))
                        submission[command[1]] = 0;
                    submission[command[1]]++;
                }
                else
                {
                    if (personResult[command[0]] < int.Parse(command[2]))
                        personResult[command[0]] = int.Parse(command[2]);
                    submission[command[1]]++;
                }     
                command = Console.ReadLine().Split("-");
            }

            Console.WriteLine("Results:");
            foreach (var kvp in personResult.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in submission.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
