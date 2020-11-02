using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vechicle
    {
        private const double AirConditionConsumption = 1.6;
        public Truck(double fuelQuanity, double FuelConsumptionPerKm,double tankCapcity) : base(fuelQuanity, FuelConsumptionPerKm,tankCapcity)
        {
            this.FuelConsumptionPerKm += AirConditionConsumption;
        }

        public override void DriveDistance(double distance)
        {
            double leftFuel = this.FuelQuantity - this.FuelConsumptionPerKm * distance;
            if (leftFuel > 0)
            {
                this.FuelQuantity = leftFuel;
                Console.WriteLine($"{nameof(Truck)} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Truck)} needs refueling");
            }
        }

        public override void Refueld(double fuel)
        {
            if (this.TankCapacity < this.FuelQuantity + fuel)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            fuel *= 0.95;
            base.Refueld(fuel);
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
