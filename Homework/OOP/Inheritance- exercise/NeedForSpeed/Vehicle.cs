using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption
            => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            bool canDrive = this.Fuel - kilometers * this.FuelConsumption >= 0;
            if (canDrive)
                this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
