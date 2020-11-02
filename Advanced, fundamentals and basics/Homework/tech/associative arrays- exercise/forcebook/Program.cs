using System;
using System.Collections.Generic;
using System.Linq;

namespace forcebook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<forceSide,forceUser>
            var force = new Dictionary<string, List<string>>();
            string commandStr = string.Empty;

            while ((commandStr = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] command = commandStr.Split(" | ").ToArray();
                //first type of command splited by |
                if (command.Length == 2)
                {
                    if (!force.ContainsKey(command[0]))
                    {
                        force[command[0]] = new List<string>();
                    }
                    if (!force[command[0]].Contains(command[1]))
                    {
                        force[command[0]].Add(command[1]);
                    }
                }
                else if (command.Length == 1)
                {
                    command = commandStr.Split(" -> ").ToArray();
                    //second type of command splited by ->
                    if (!force.ContainsKey(command[1]))
                    {
                        force[command[1]] = new List<string>();
                    }
                    foreach (var kvp in force)
                    {
                        if (kvp.Value.Contains(command[0]))
                        {
                            kvp.Value.Remove(command[0]);
                        }
                    }
                    force[command[1]].Add(command[0]);
                    Console.WriteLine($"{command[0]} joins the {command[1]} side!");

                }
            }
            //print
            foreach (var kvp in force
                .Where(x => x.Value.Count >= 1)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
