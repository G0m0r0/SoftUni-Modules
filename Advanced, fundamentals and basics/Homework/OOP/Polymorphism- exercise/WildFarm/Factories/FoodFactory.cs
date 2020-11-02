using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string[] args)
        {
            string type = args[0];
            int quantity = int.Parse(args[1]);

            switch (type.ToLower())
            {
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
