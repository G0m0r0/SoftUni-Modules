using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        private double tire1Pressure;
        private double tire2Pressure;
        private double tire3Pressure;
        private double tire4Pressure;
        private int tire1Age;
        private int tire2Age;
        private int tire3Age;
        private int tire4Age;

        public int Tire4Age
        {
            get { return tire4Age; }
            set { tire4Age = value; }
        }

        public int Tire3Age
        {
            get { return tire3Age; }
            set { tire3Age = value; }
        }

        public int Tire2Age
        {
            get { return tire2Age; }
            set { tire2Age = value; }
        }
        public int Tire1Age
        {
            get { return tire1Age; }
            set { tire1Age = value; }
        }

        public double Tire4Pressure
        {
            get { return tire4Pressure; }
            set { tire4Pressure = value; }
        }


        public double Tire3Pressure
        {
            get { return tire3Pressure; }
            set { tire3Pressure = value; }
        }

        public double Tire2Pressure
        {
            get { return tire2Pressure; }
            set { tire2Pressure = value; }
        }

        public double Tire1Pressure
        {
            get { return tire1Pressure; }
            set { tire1Pressure = value; }
        }
        public Tire(double tire1Pressure, double tire2Pressure, double tire3Pressure, double tire4Pressure,int tire1Age, int tire2Age, int tire3Age, int tire4Age)
        {
            Tire1Age = tire1Age;
            Tire2Age = tire2Age;
            Tire3Age = tire3Age;
            Tire4Age = tire4Age;

            Tire1Pressure = tire1Pressure;
            Tire2Pressure = tire2Pressure;
            Tire3Pressure = tire3Pressure;
            Tire4Pressure = tire4Pressure;

        }

        public bool GetPressure()
        {
            double tirePressure = (tire1Pressure + tire2Pressure + tire3Pressure + tire4Pressure) / 4;
            if (tirePressure<1)
            {
                return true;
            }
            return false;
        }
    }
}
