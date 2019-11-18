using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }

        public override void EatFood(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
