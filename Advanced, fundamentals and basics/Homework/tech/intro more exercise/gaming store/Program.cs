using System;

namespace gaming_store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            string choice = string.Empty;
            decimal gamePrice = 0;
            decimal totalSpend = 0;
            do
            {
                choice = Console.ReadLine();
                if(choice=="Game Time") break;
                switch (choice)
                {
                    case "OutFall 4": gamePrice = 39.99m; break;
                    case "CS: OG": gamePrice = 15.99m; break;
                    case "Zplinter Zell": gamePrice = 19.99m; break;
                    case "Honored 2": gamePrice = 59.99m; break;
                    case "RoverWatch": gamePrice = 29.99m; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99m; break;
                    default:
                        {
                            Console.WriteLine("Not Found");
                            continue;
                        }
                }
                if (gamePrice <= money)
                {
                    money -= gamePrice;
                    totalSpend += gamePrice;
                    Console.WriteLine($"Bought {choice}");
                }
                else Console.WriteLine("Too Expensive");
                if (money == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            } while ( money != 0);
            //choice != "Game Time" ||
            Console.WriteLine($"Total spent: ${totalSpend}. Remaining: ${money} ");
        }
    }
}
