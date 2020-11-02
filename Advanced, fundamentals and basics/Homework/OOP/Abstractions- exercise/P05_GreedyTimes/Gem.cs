using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gem
    {
        public string Name { get; set; }
        public long Amount { get; set; }
        public Gem(string name,long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}";
        }
    }
}
