using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight,string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get;private set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.Weight}, {this.Weight},{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
