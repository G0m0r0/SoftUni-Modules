using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name,double weight,int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        protected string Name { get; set; }
        protected double Weight { get; set; }
        protected int FoodEaten { get; set; }

        public virtual void AskForFood()
        {
            Console.WriteLine("Animal ask for food");
        }
    }
}
