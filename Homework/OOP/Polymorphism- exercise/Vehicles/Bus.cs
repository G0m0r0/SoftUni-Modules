using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vechicle
    {
        private const double DrivePeopleConst = 1.4;
        private double defaultFuelConsumption;
        public Bus(double fuelQuanity, double FuelConsumptionPerKm, double tankCapacity) : base(fuelQuanity, FuelConsumptionPerKm, tankCapacity)
        {
            this.defaultFuelConsumption = FuelConsumptionPerKm;
        }
        protected bool IsPeopleInside { get; set; }

        public bool IsEmpty { get; set; }
        public override void DriveDistance(double distance)
        {            
            if(!IsEmpty)
            {
                this.FuelConsumptionPerKm += DrivePeopleConst;
            }
            double leftFuel = this.FuelQuantity - this.FuelConsumptionPerKm * distance;

            Drive(distance,leftFuel);

            this.FuelConsumptionPerKm = defaultFuelConsumption;
        }

        private void Drive(double distance,double leftFuel)
        {
            if (leftFuel > 0)
            {
                this.FuelQuantity = leftFuel;
                Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{nameof(Bus)} needs refueling");
            }
        }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}
