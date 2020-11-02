using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeight = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFood = new List<string>
            {
                "Vegetable",
                "Meat"
            };
        }
        protected override double WeightMultiplier
            => CatWeight;

        protected override ICollection<string> AllowedFood { get; }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food==null)
            {
                throw new Exception($"{nameof(Cat)} does not eat {typeof(Food)}!");               
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
        }

        public override string ToString()
        {
            return $"{nameof(Cat)}" + base.ToString();
        }
    }
}
