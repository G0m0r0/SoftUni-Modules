using System;

namespace vending_machine
{
    class Program
    {
        static void Main()
        {
            string money = string.Empty;
            decimal moneySum = 0;
            do
            {
                money = Console.ReadLine();
                if (money != "Start")
                {
                    if(money=="0.1"||money=="0.2"||money=="0.5"||money=="1"||money=="2")
                    moneySum += decimal.Parse(money);
                    else Console.WriteLine("Cannot accept {0}",money);
                }
            } while (money!="Start");

            string choice = string.Empty;
            do
            {
                choice = Console.ReadLine();
                if (choice != "End")
                {
                    switch (choice)
                    {
                        case "Nuts":
                            {
                                moneySum -= 2m;
                                if (moneySum < 0)
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                    moneySum += 2m;
                                }
                                else Console.WriteLine("Purchased {0}", choice.ToLower());
                            }
                            break;
                        case "Water":
                            {
                                moneySum -= 0.7m;
                                if (moneySum < 0)
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                    moneySum += 0.7m;
                                }
                                else Console.WriteLine("Purchased {0}", choice.ToLower());
                            }
                            break;
                        case "Crisps":
                            {
                                moneySum -= 1.5m;
                                if (moneySum < 0)
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                    moneySum += 1.5m;
                                }
                                else Console.WriteLine("Purchased {0}", choice.ToLower());
                            }
                            break;
                        case "Soda":
                            {
                                moneySum -= 0.8m;
                                if (moneySum < 0)
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                    moneySum += 0.8m;
                                }
                                else Console.WriteLine("Purchased {0}", choice.ToLower());
                            }
                            break;
                        case "Coke":
                            {
                                moneySum -= 1m;
                                if (moneySum < 0)
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                    moneySum += 1m;
                                }
                                else Console.WriteLine("Purchased {0}", choice.ToLower());
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid product");
                            break;
                    }
                   
                }
            } while (choice!="End");
            Console.WriteLine("Change: {0:F2}",moneySum);
        }
    }
}
