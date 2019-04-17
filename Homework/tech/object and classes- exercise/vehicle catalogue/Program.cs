using System;
using System.Collections.Generic;
using System.Linq;

namespace vehicle_catalogue
{
    class Vehicle
    {
        public Vehicle(string typeOfVehicle, string model, string color, string horsepower)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string TypeOfVehicle { set; get; }
        public string Model { set; get; }
        public string Color { set; get; }
        public string Horsepower { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            
            CreateListOfVehicles(vehicles);

            PrintDataOfVehicle(vehicles);

            AverageHorsepower(vehicles);
        }

        private static void AverageHorsepower(List<Vehicle> vehicles)
        {
            double averageCarPower = 0;
            double averageTruckPower = 0;
            int countCars = 0;
            int countTrucks = 0;
            foreach (var item in vehicles)
            {
                if (item.TypeOfVehicle == "car")
                {
                    averageCarPower += double.Parse(item.Horsepower);
                    countCars++;
                }
                else if (item.TypeOfVehicle == "truck")
                {
                    averageTruckPower += double.Parse(item.Horsepower);
                    countTrucks++;
                }
            }
            Console.WriteLine($"Cars have average horsepower of: {(averageCarPower / countCars):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {(averageTruckPower / countTrucks):f2}.");
        }

        private static void PrintDataOfVehicle(List<Vehicle> vehicles)
        {
            string vehicleModel = Console.ReadLine();
            while (vehicleModel != "Close the Catalogue")
            {
                {
                    if(vehicles.Select(x=>x.Model).Contains(vehicleModel))
                    foreach (var item in vehicles)
                    {
                        if (item.Model == vehicleModel)
                        {
                            if (item.TypeOfVehicle == "car")
                                Console.WriteLine($"Type: {item.TypeOfVehicle.Replace('c', 'C')}");
                            else
                                Console.WriteLine($"Type: {item.TypeOfVehicle.Replace('t', 'T')}");
                            Console.WriteLine($"Model: {item.Model}");
                            Console.WriteLine($"Color: {item.Color}");
                            Console.WriteLine($"Horsepower: {item.Horsepower}");
                            break;
                        }
                    }
                }

                vehicleModel = Console.ReadLine();
            }
        }

        private static void CreateListOfVehicles(List<Vehicle> vehicles)
        {
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                Vehicle vehicle = new Vehicle(command[0], command[1], command[2], command[3]);
                vehicles.Add(vehicle);
                command = Console.ReadLine().Split();
            }
        }
    }
}
