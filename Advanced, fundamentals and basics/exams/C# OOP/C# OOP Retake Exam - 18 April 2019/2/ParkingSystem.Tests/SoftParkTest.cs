namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        [Test]
        public void TestConstructorIfInitializeDictionarycorrctly()
        {
            var parking = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            var softpark = new SoftPark();

            Assert.AreEqual(parking, softpark.Parking);
        }

        [Test]
        public void ThrowArgumentExceptionWhenParkingSpotDoesNotExsit()
        {
            var softPark = new SoftPark();
            string parkSpot = "C5";
            Car car = new Car("MyCar", "123456");

            Assert.Throws<ArgumentException>(()=>softPark.ParkCar(parkSpot, car));
        }
        [Test]
        public void ThrowArgumentExceptionWhenParkingSpotIsAlreadytaken()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car carAlreadyParked = new Car("MyParkedCar", "1234567");
            softPark.ParkCar(parkSpot, carAlreadyParked);

            Car car = new Car("OtherCar", "1234");

            Assert.Throws<ArgumentException>(() => softPark.ParkCar(parkSpot, car));
        }
        [Test]
        public void ThrowInvalidOperationExceptionWhenTheCarIsAlreadyParked()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");
            softPark.ParkCar(parkSpot, car);

            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("C2", car));
        }

        [Test]
        public void TestIfCarIsParkedCorrectly()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");
            softPark.ParkCar(parkSpot, car);

            Assert.AreEqual(softPark.Parking["C4"], car);
        }

        [Test]
        public void TestIfParkedCarreturnMessageWithRegistrationNum()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");

            Assert.AreEqual(softPark.ParkCar(parkSpot, car), $"Car:123456 parked successfully!");
        }

        [Test]
        public void TestWhenParkingSpotDoesntExit()
        {
            var softPark = new SoftPark();
            string parkSpot = "C5";
            Car car = new Car("MyCar", "123456");

            Assert.Throws<ArgumentException>(()=>softPark.RemoveCar(parkSpot, car));
        }

        [Test]
        public void TestWhenParkedCarOnThatSpotdoesntExit()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");
            softPark.ParkCar(parkSpot, car);

            Car otherCar = new Car("NotMyCar", "98765");

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar(parkSpot, otherCar));
        }

        [Test]
        public void TestSuccessfulRemoving()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");
            softPark.ParkCar(parkSpot, car);
            softPark.RemoveCar(parkSpot, car);

            Assert.AreEqual(softPark.Parking["C4"], null);            
        }

        [Test]
        public void TestOutputMessageWhenRemoveCar()
        {
            var softPark = new SoftPark();
            string parkSpot = "C4";
            Car car = new Car("MyCar", "123456");
            softPark.ParkCar(parkSpot, car);            

            Assert.AreEqual(softPark.RemoveCar(parkSpot, car), $"Remove car:123456 successfully!");
        }
    }
}