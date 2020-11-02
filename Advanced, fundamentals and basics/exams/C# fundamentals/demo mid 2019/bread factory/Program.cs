using System;
using System.Collections.Generic;
using System.Linq;

namespace bread_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //its wrong
            List<string> workingDays = Console.ReadLine()
                .Split("|")
                .ToList();

            int intialCoins = 100;
            int intialEnergy = 100;
            for (int i = 0; i < workingDays.Count; i++)
            {
                string[] token = workingDays[i].Split("-").ToArray();

                switch (token[0])
                {
                    case "rest":
                        if (int.Parse(token[1]) + intialEnergy <= 100)
                        {
                            Console.WriteLine("You gained {0} energy.", token[1]);
                            intialEnergy += int.Parse(token[1]);
                        }
                        else
                        {
                            Console.WriteLine("You gained {0} energy.", 100 - intialEnergy);
                            intialEnergy = 100;
                        }
                        Console.WriteLine("Current energy: {0}.", intialEnergy);
                        break;
                    case "order":
                        intialEnergy -= 30;
                        if (intialEnergy < 0)
                        {
                            intialEnergy = 50;
                            Console.WriteLine("You had to rest!");
                        }
                        else
                        {
                            Console.WriteLine("You earned {0} coins.", token[1]);
                            intialCoins += int.Parse(token[1]);
                        }
                        break;

                    default:
                        if (intialCoins - int.Parse(token[1]) >= 0)
                        {
                            Console.WriteLine("You bought {0}.", token[0]);
                            intialCoins -= int.Parse(token[1]);

                        }
                        else
                        {
                            Console.WriteLine("Closed! Cannot afford {0}.", token[0]);
                            return;
                        }
                        break;
                }
                // Console.WriteLine("eng {0}",);
            }
            Console.WriteLine($"Day completed!\nCoins: {intialCoins}\nEnergy: {intialEnergy}");
        }
    }
}
