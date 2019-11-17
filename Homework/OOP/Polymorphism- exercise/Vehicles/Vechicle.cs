using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vechicle
    {
        public Vechicle(double fuelQuanity, double FuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuanity;
            this.FuelConsumptionPerKm = FuelConsumptionPerKm;
        }
        public double TankCapacity { get; set; }
        private double fuelQuantity;

        protected double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        protected double FuelConsumptionPerKm { get; set; }

        public abstract void DriveDistance(double distance);

        public virtual void Refueld(double fuel)
        {
            if (this.TankCapacity < this.FuelQuantity + fuel)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            if (fuel <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }

            this.FuelQuantity += fuel;

        }

    }
}
