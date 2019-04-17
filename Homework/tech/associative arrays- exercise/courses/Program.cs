using System;
using System.Collections.Generic;
using System.Linq;

namespace courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var course = new Dictionary<string, List<string>>();

            string[] command = Console.ReadLine().Split(" : ");
            while (command[0] != "end")
            {
                if (!course.ContainsKey(command[0]))
                {
                    course.Add(command[0], new List<string> { command[1] });
                }
                else
                {
                    course[command[0]].Add(command[1]);
                }

                command = Console.ReadLine().Split(" : ");
            }

            foreach (var kvp in course.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var person in kvp.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {person}");
                }
            }
        }
    }
}
