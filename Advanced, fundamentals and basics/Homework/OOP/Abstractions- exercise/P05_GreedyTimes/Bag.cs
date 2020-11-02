using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        public List<Cash> Cash;
        public List<Gem> Gems;
        public long Gold { get; set; }

        public Bag()
        {
            this.Gold = 0;
            this.Cash = new List<Cash>();
            this.Gems = new List<Gem>();
        }

        public void AddGem(Gem gem)
        {
            this.Gems.Add(gem);
        }

        public void AddCash(Cash cash)
        {
            this.Cash.Add(cash);
        }

        public void AddGold(long gold)
        {
            this.Gold += gold;
        }

        public long SumGems()
        {
            long sum = 0;
            foreach (var gem in this.Gems)
            {
                sum += gem.Amount;
            }

            return sum;
        }

        public long SumCash()
        {
            long sum = 0;
            foreach (var amount in this.Cash)
            {
                sum += amount.Amount;
            }
            return sum;
        }

        public long TotalCapacity()
        {
            return SumCash() + SumGems() + this.Gold;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Gold > 0)
            {
                sb.AppendLine($"<Gold> ${this.Gold}");
                sb.AppendLine($"##Gold - {this.Gold}");
            }

            if (this.Gems.Count > 0)
            {
                sb.AppendLine($"<Gem> ${this.SumGems()}");
                foreach (var gem in this.Gems.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine(gem.ToString());
                }
            }           

            if(this.Cash.Count>0)
            {
                sb.AppendLine($"<Cash> ${this.SumCash()}");
                foreach (var papper in Cash.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine(papper.ToString());
                }
            }
            

            return sb.ToString().TrimEnd();
        }
    }
}
