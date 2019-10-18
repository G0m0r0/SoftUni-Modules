using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfEgines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numOfEgines; i++)
            {
                int displacement = 0;
                string efficiency = string.Empty;

                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                if (tokens.Length > 2)
                {
                    if (int.TryParse(tokens[2], out int num))
                        displacement = num;
                    else
                        efficiency = tokens[2];
                }
                if(tokens.Length>3)
                {
                    efficiency = tokens[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int numOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numOfCars; i++)
            {
                int weight = 0;
                string color = string.Empty;
                string[] tokens = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                string model = tokens[0];
                string engine = tokens[1];
                if (tokens.Length > 2)
                {
                    if (int.TryParse(tokens[2], out int num))
                        weight = num;
                    else
                        color = tokens[2];
                }
                if(tokens.Length>3)
                {
                    color = tokens[3];
                }
                      
                Engine searchedEngine = engines.First(x => x.Model == engine);
                Car car = new Car(model, searchedEngine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement != 0)
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                else
                    Console.WriteLine("    Displacement: n/a");
                if (car.Engine.Efficiency != string.Empty)
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                else
                    Console.WriteLine($"    Efficiency: n/a");
                if (car.Weight != 0)
                    Console.WriteLine($"  Weight: {car.Weight}");
                else
                    Console.WriteLine("  Weight: n/a");
                if (car.Color != string.Empty)
                    Console.WriteLine($"  Color: {car.Color}");
                else
                    Console.WriteLine("  Color: n/a");

            }
        }
    }
}
