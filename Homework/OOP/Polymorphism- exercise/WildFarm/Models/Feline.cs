using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight,string livingRegion,string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
        protected string Breed { get;private set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.Breed}, {this.Weight},{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
