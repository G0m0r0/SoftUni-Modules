using System;
using System.Collections.Generic;
using System.Linq;

namespace dungeonest_dark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            List<string> rooms = Console.ReadLine()
                .Split("|")
                .ToList();

            for (int i = 0; i < rooms.Count; i++)
            {           
                string[] token = rooms[i].Split().ToArray();
                switch (token[0])
                {
                    case "potion":
                        if (health + int.Parse(token[1]) > 100)
                        {
                            Console.WriteLine("You healed for {0} hp.", 100 - health);
                            health = 100;
                        }
                        else
                        {
                            Console.WriteLine("You healed for {0} hp.",token[1]);
                            health += int.Parse(token[1]);
                        }
                        Console.WriteLine("Current health: {0} hp.", health);
                        break;
                    case "chest":
                        Console.WriteLine("You found {0} coins.",token[1]);
                        coins += int.Parse(token[1]);
                        break;
                    default:
                        if (health - int.Parse(token[1]) > 0)
                        {
                            Console.WriteLine("You slayed {0}.", token[0]);
                            health -= int.Parse(token[1]);
                        }
                        else
                        {
                            Console.WriteLine("You died! Killed by {0}.", token[0]);
                            Console.WriteLine($"Best room: {i+1}");
                            return;
                        }
                        break;
                }
            }
                Console.WriteLine($"You've made it!\nCoins: {coins}\nHealth: {health}");            
        }
    }
}
