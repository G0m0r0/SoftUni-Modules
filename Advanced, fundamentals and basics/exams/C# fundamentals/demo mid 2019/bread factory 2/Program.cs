using System;
using System.Collections.Generic;
using System.Linq;

namespace bread_factory_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = 100;
            int coins = 100;
            List<string> days = Console.ReadLine()
                .Split("|")
                .ToList();

            for (int i = 0; i < days.Count; i++)
            {
                string[] token = days[i].Split("-").ToArray();
                switch (token[0])
                {
                    case "rest":
                        if(energy+int.Parse(token[1])<=100)
                        {
                            Console.WriteLine($"You gained {token[1]} energy.");
                            energy += int.Parse(token[1]);
                        }
                        else
                        {
                            Console.WriteLine($"You gained {100-energy} energy.");
                            energy = 100;
                        }
                        Console.WriteLine($"Current energy: {energy}.");
                        break;
                    case "order":
                        energy -= 30;
                        if(energy>=0)
                        {
                            Console.WriteLine($"You earned {token[1]} coins.");
                            coins += int.Parse(token[1]);
                        }
                        else
                        {
                            energy += 80;
                            Console.WriteLine("You had to rest!");
                        }                        
                        break;
                    default:
                        coins -= int.Parse(token[1]);
                        if(coins>0)
                        {
                            Console.WriteLine($"You bought {token[0]}.");
                        }
                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {token[0]}.");
                            return;
                        }
                        break;
                }
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
