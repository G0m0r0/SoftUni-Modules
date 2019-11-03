using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Cash
    {
        public Cash(string name, long amount)
        {
            this.Amount = amount;
            this.Name = name;
        }
        public string Name { get; set; }
        public long Amount { get; set; }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}";
        }
    }
}
