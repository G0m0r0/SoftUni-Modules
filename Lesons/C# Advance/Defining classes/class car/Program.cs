using System;

namespace class_car
{
    class Car
    {
        public string Make { get; set; }

        //public string Make { get; private set; } = "Audi"; //all of the cars are Audi
        //public string Make { get; set; } = "Audi"; //default is Audi but we can change it        
        public string Model { get; set; }
        public int Year { get; set; }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public Car(string make,string model)
        {
            this.Make = make;
            this.Model = model;
            this.FuelConsumption = 12;
        }

        public Car(string make,string model,int year): this(make,model)
        {
            this.Year = year;
        }
        public Car()
        {

        }

        public void Drive(double distance)
        {
            var consumption = distance * this.FuelConsumption/100.0;
            if(consumption<this.FuelQuantity)
            {
                this.FuelQuantity -= consumption;
            }
            else
            {
                throw new Exception($"Enable to drive {distance} km.");
            }
        }

        public string WhoAmI()
        {
            return $"{this.Make} {this.Model} {this.Year}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Audi";
            car.Model = "A7";
            car.Year = 2005;

            Console.WriteLine(car.WhoAmI());
            car.FuelConsumption = 12;
            car.FuelQuantity = 80;
            car.Drive(400);
            car.Drive(200);
           // car.Drive(100); //throw error
        }
    }
}
