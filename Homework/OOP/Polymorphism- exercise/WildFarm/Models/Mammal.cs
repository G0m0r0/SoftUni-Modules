using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten,string livingRegion) 
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}
