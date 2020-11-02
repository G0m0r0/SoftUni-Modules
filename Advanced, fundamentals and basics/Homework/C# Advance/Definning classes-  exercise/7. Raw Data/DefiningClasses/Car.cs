using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Cargo cargo;
        private Engine engine;
        private Tire tire;

        public Tire Tire
        {
            get { return tire; }
            set { tire = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Car(string model,Cargo cargo,Engine engine,Tire tire)
        {
            Model = model;
            Cargo = cargo;
            Engine = engine;
            Tire = tire;
        }
    }
}
