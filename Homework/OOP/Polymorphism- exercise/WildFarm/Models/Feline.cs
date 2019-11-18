using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten,string livingRegion,string breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }
        protected string Breed { get; set; }

    }
}
