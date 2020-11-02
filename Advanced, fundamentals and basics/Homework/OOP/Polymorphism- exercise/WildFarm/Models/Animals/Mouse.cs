using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier => throw new NotImplementedException();

        protected override ICollection<string> AllowedFood => throw new NotImplementedException();

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
