using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Remove(0, 6);

                string[] inputDough = Console.ReadLine()
                    .Split();

                string flourtype = inputDough[1];
                string backingTech = inputDough[2];
                double weight = double.Parse(inputDough[3]);

                Dough dough = new Dough(flourtype, backingTech, weight);
                Pizza pizza = new Pizza(pizzaName, dough);


                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = command.Split();

                    string toppingType = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }


                Console.WriteLine($"{pizzaName} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
