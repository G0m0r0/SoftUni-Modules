using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorCreatorOfACar()
        {
            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }
        [Test]
        public void ModelShouldThrowArgumentExecptionWhenItsNull()
        {
            string make = "BMV";
            string model = null;
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void MakeShouldThrowArgumentExecptionWhenItsNull()
        {
            string make = null;
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowArgumentExecptionIfBelowZero()
        {
            string make = "BMW";
            string model = "G52";
            double fuelConsumption = -10;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelConsumptionShouldThrowArgumentExecptionIfEqualToZero()
        {
            string make = "BMW";
            string model = "G52";
            double fuelConsumption = 0;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgumentExecptionIfBelowZero()
        {
            string make = "BMW";
            string model = "G52";
            double fuelConsumption = 5;
            double fuelCapacity = -10;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgumentExecptionEqualToZero()
        {
            string make = "BMW";
            string model = "G52";
            double fuelConsumption = 5;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [TestCase(null, "Golf", 10, 20)]
        [TestCase("BMW", null, 10, 20)]
        [TestCase("BMW", "Golf", -5, 20)]
        [TestCase("BMW", "Golf", 0, 20)]
        [TestCase("BMW", "Golf", 10, -5)]
        [TestCase("BMW", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void TestNegativeRefuiling(double fuelToRefuel)
        {
            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void TestFuelCapacityIfItsTooMuch()
        {
            var fuelToRefuel = 100;

            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.IsTrue(fuelCapacity == car.FuelAmount);
        }

        [Test]
        public void ShouldRefuilNormaly()
        {
            var fuelToRefuel = 5;

            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);

            Assert.IsTrue(fuelToRefuel == car.FuelAmount);
        }

        [Test]
        public void ShouldDriveNormaly()
        {
            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DistanceIsTooMuchToDrive()
        {
            var distance = 1000;

            string make = "BMV";
            string model = "G52";
            double fuelConsumption = 20.5;
            double fuelCapacity = 10.5;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}