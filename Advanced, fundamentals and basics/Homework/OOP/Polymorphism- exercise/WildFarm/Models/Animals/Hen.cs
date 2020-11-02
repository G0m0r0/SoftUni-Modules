using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => throw new NotImplementedException();

        protected override ICollection<string> AllowedFood => throw new NotImplementedException();

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
