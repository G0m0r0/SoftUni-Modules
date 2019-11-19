using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name,double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        protected string Name { get; set; }
        protected double Weight { get; set; }
        protected int FoodEaten { get; set; }

        public abstract void AskForFood();

        protected abstract double WeightMultiplier { get; }
        protected abstract ICollection<string> AllowedFood { get; }
        public abstract void Eat(Food food);
         
    }
}
