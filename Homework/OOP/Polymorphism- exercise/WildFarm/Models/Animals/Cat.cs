using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }

        public override void EatFood(Food food)
        {
            if(food.GetType().Name.Equals("Vegetable"))
            {
                this.Weight += 0.3;
            }
            else
            {
                throw new Exception($"{nameof(Cat)} does not eat {food.GetType().Name}!");
            }
        }
    }
}
