using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = 0; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Car(string model)
        {
            Model = model;
        }
        public Car(string model,double fuelAmount,double fuelConsumptionFor1km)
            :this(model)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }

        public void Drive(string model,double amountOfKm)
        {
            if(fuelAmount>amountOfKm*fuelConsumptionPerKilometer)
            {
                fuelAmount -= amountOfKm * fuelConsumptionPerKilometer;
                travelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
