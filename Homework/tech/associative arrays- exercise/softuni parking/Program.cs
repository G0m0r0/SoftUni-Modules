using System;
using System.Collections.Generic;

namespace softuni_parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var cars = new Dictionary<string, string>();
            for (int i = 0; i < num; i++)
            {
                string[] token = Console.ReadLine().Split();
                switch (token[0])
                {
                    case "register":
                        Registration(cars, token[1], token[2]);
                        break;
                    case "unregister":
                        Unregister(cars, token[1]);
                        break;
                    default:
                        break;
                }
            }

            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }

        private static void Unregister(Dictionary<string, string> cars, string username)
        {
            if (!cars.ContainsKey(username))
                Console.WriteLine($"ERROR: user {username} not found");
            else
            {
                cars.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
        }

        private static void Registration(Dictionary<string, string> cars, string username, string plateNum)
        {
            if (cars.ContainsKey(username))
                Console.WriteLine($"ERROR: already registered with plate number {cars[username]}");
            else
            {
                cars[username] = plateNum;
                Console.WriteLine($"{username} registered {plateNum} successfully");
            }
        }
    }
}
