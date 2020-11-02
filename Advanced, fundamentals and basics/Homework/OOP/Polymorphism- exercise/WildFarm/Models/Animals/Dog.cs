using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeight = 0.4;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AllowedFood = new List<string>
            {
                "Meat"
            };
        }

        protected override double WeightMultiplier => DogWeight;

        protected override ICollection<string> AllowedFood { get; }

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(Food food)
        {
            if (!this.AllowedFood.Contains(food.GetType().Name))
            {
                throw new Exception($"{nameof(Dog)} does not eat {typeof(Food)}!");
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
        }
    }
}
