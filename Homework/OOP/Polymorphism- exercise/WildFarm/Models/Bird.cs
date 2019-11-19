using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        protected double WingSize { get;private set; }

        public override string ToString()
        {
            return $"[{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
