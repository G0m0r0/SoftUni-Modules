using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => throw new NotImplementedException();

        protected override ICollection<string> AllowedFood => throw new NotImplementedException();

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
