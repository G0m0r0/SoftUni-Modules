using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long Capacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // var bag = new Dictionary<string, Dictionary<string, long>>();
            //long gold = 0;
            //long stones = 0;
            //long cash = 0;
            Bag bag = new Bag();

            for (int i = 0; i < safe.Length; i += 2)
            {
                string nameOfItem = safe[i];
                long amountItem = long.Parse(safe[i + 1]);

                string type = string.Empty;

                if (nameOfItem.Length == 3)
                {
                    type = "Cash";
                }
                else if (nameOfItem.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (nameOfItem.ToLower() == "gold")
                {
                    type = "Gold";
                }
                else
                {
                    continue;
                }

                if(Capacity<bag.TotalCapacity()+amountItem)
                {
                    continue;
                }

                if (type == "Gold")
                {
                    bag.AddGold(amountItem);
                }
                else if (type == "Gem")
                {
                    Gem gem = new Gem(nameOfItem,amountItem);
                    if (bag.Gold >= bag.SumGems() + amountItem)
                    {
                        bag.AddGem(gem);
                    }
                }
                else if (type == "Cash")
                {
                    Cash cash = new Cash(nameOfItem, amountItem);
                    if (bag.SumGems()>=bag.SumCash()+amountItem)
                    {
                        bag.AddCash(cash);
                    }
                    
                }
            }

            Console.WriteLine(bag);
        }
    }
}