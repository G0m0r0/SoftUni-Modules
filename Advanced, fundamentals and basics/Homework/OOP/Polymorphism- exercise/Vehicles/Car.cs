using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vechicle
    {
        private const double SummerFuelConsumption = 0.9;
        public Car(double fuelQuanity, double FuelConsumptionPerKm,double tankCapacity) : base(fuelQuanity, FuelConsumptionPerKm,tankCapacity)
        {
            this.FuelConsumptionPerKm += SummerFuelConsumption;
        }
        public override void DriveDistance(double distance)
        {
            double leftFuel = this.FuelQuantity - this.FuelConsumptionPerKm * distance;
            if (leftFuel > 0)
            {
                this.FuelQuantity = leftFuel;
                Console.WriteLine($"{nameof(Car)} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Car)} needs refueling");
            }
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
