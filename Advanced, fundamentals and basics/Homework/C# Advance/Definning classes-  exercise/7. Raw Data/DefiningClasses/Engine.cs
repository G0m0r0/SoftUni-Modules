using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private double engineSpeed;
        private double enginePower;

        public double EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }


        public double EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }
        public Engine(double enginePower,double engineSpeed)
        {
            EnginePower = enginePower;
            EngineSpeed = engineSpeed;
        }
    }
}
