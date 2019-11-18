using System;
using System.Collections.Generic;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            string command = string.Empty;
            List<Animal> animals = new List<Animal>();

            while ((command = Console.ReadLine()) != "End")
            {
                //TODO: try catch exeptions
                string[] args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = args[0];
                string name = args[1];
                double weight = double.Parse(args[2]);

                string[] foodInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInput[0];
                int foodQuanity = int.Parse(foodInput[1]);

                //TODO: if food is null
                Food food = null;
                switch (foodType)
                {
                    case "Vegetable":
                        food = new Vegetable(foodQuanity);
                        break;
                    case "Fruit":
                        food = new Fruit(foodQuanity);
                        break;
                    case "Meat":
                        food = new Meat(foodQuanity);
                        break;
                    case "Seeds":
                        food = new Seeds(foodQuanity);
                        break;
                    default:
                        break;
                }

                Animal animal = null;
                switch (type)
                {
                    case "Owl":
                        double wingsSize = double.Parse(args[3]);
                        animal = new Owl(name, weight, foodQuanity, wingsSize);
                        break;
                    case "Hen":
                        wingsSize = double.Parse(args[3]);
                        animal = new Hen(name, weight, foodQuanity, wingsSize);
                        break;
                    case "Mouse":
                        string livingRegion = args[3];
                        animal = new Mouse(name, weight, foodQuanity, livingRegion);
                        break;
                    case "Dog":
                        livingRegion = args[3];
                        animal = new Dog(name, weight, foodQuanity, livingRegion);
                        break;
                    case "Cat":
                        livingRegion = args[3];
                        string breed = args[4];
                        animal = new Cat(name, weight, foodQuanity, livingRegion, breed);
                        break;
                    case "Tiger":
                        livingRegion = args[3];
                        breed = args[4];
                        animal = new Tiger(name, weight, foodQuanity, livingRegion, breed);
                        break;
                }

                animal.EatFood(food);
                animals.Add(animal);
            }
        }
    }
}
