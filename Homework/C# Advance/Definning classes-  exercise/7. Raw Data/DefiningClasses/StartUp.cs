using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = tokens[0];
                int engineSpeed =int.Parse( tokens[1]);
                int enginePower =int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                double tire2Pressure =double.Parse( tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Cargo cargo = new Cargo(cargoType,cargoWeight);
                Engine engine = new Engine(enginePower, engineSpeed);
                Tire tire = new Tire(tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure, tire1Age, tire2Age, tire3Age, tire4Age);
                Car car = new Car(model, cargo, engine, tire);

                cars.Add(car);
            }
            string statement = Console.ReadLine();
            List<Car> fragileCar = new List<Car>();
            if (statement=="fragile")
            {
                  fragileCar = cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tire.GetPressure()).ToList();
                
            }
            else if(statement=="flamable")
            {
                fragileCar = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in fragileCar)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
