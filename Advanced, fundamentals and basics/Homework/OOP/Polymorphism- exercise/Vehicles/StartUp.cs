using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = CreateCar(Console.ReadLine());
            Truck truck = CreatTruck(Console.ReadLine());
            Bus bus = CreatBus(Console.ReadLine());

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string vechicle = command[1];
                double value = double.Parse(command[2]);
                try
                {
                    if (vechicle == "Car")
                    {
                        if (action == "Drive")
                        {
                            car.DriveDistance(value);
                        }
                        else if (action == "Refuel")
                        {
                            car.Refueld(value);
                        }
                    }
                    else if (vechicle == "Truck")
                    {
                        if (action == "Drive")
                        {
                            truck.DriveDistance(value);
                        }
                        else if (action == "Refuel")
                        {
                            truck.Refueld(value);
                        }
                    }
                    else if (vechicle == "Bus")
                    {
                        if (action == "Drive")
                        {
                            bus.DriveDistance(value);
                        }
                        else if (action == "Refuel")
                        {
                            bus.Refueld(value);
                        }
                        else if (action == "DriveEmpty")
                        {
                            bus.IsEmpty = true;
                            bus.DriveDistance(value);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Truck CreatTruck(string args)
        {
            string[] truckTokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuel = double.Parse(truckTokens[1]);
            double litersPerKm = double.Parse(truckTokens[2]);
            double tankCapcity = double.Parse(truckTokens[3]);

            return new Truck(fuel, litersPerKm,tankCapcity);
        }

        private static Car CreateCar(string args)
        {
            string[] carTokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuel = double.Parse(carTokens[1]);
            double litersPerKm = double.Parse(carTokens[2]);
            double tankCapcity = double.Parse(carTokens[3]);

            return new Car(fuel, litersPerKm,tankCapcity);
        }

        private static Bus CreatBus(string args)
        {
            string[] busTokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuel = double.Parse(busTokens[1]);
            double litersPerKm = double.Parse(busTokens[2]);
            double tankCapcity = double.Parse(busTokens[3]);

            return new Bus(fuel, litersPerKm, tankCapcity);
        }
    }
}
