using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
       // [Test]
       // public void TestConstructorUnitMotorcycle()
       // {
       //     string name = "Imaha";
       //     int horsePower = 100;
       //     double cubicCentimeters = 150.5;
       //     var motorcycle = new UnitMotorcycle(name, horsePower, cubicCentimeters);
       //
       //     Assert.AreEqual(motorcycle.Model, name);
       //     Assert.AreEqual(motorcycle.CubicCentimeters, cubicCentimeters);
       //     Assert.AreEqual(motorcycle.HorsePower, horsePower);
       // }

      // [Test]
      // public void TestConstructorOfMotorcycle()
      // {
      //     string model = "Imaha";
      //     int horsePower = 100;
      //     double cubicCentimeters = 150.5;
      //     var motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
      //
      //     string name = "ivan";
      //     var rider = new UnitRider(name, motorcycle);
      //
      //     Assert.AreEqual(name, rider.Name);
      //     Assert.AreEqual(motorcycle, rider.Motorcycle);
      // }
        [Test]
        public void TestWhenNameIsNull()
        {
            string model = "Imaha";
            int horsePower = 100;
            double cubicCentimeters = 150.5;
            var motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = null;

            Assert.Throws<ArgumentNullException>(() => new UnitRider(name, motorcycle));
        }

        [Test]
        public void TestWhenRiderIsInvalidNull()
        {
            string model = "Imaha";
            int horsePower = 100;
            double cubicCentimeters = 150.5;
            var motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            //string name = "Ivan";
            UnitRider rider = null; //new UnitRider(name, motorcycle);

            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void TestWhenRiderAlreadyExitst()
        {
            string model = "Imaha";
            int horsePower = 100;
            double cubicCentimeters = 150.5;
            var motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = "Ivan";
            UnitRider rider = new UnitRider(name, motorcycle);

            var race = new RaceEntry();
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void TestSuccessfullAddedRider()
        {
            string model = "Imaha";
            int horsePower = 100;
            double cubicCentimeters = 150.5;
            var motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = "Ivan";
            UnitRider rider = new UnitRider(name, motorcycle);

            var race = new RaceEntry();

            Assert.AreEqual($"Rider {rider.Name} added in race.", race.AddRider(rider));
        }

        [Test]
        public void CalculateAvrHorsePowerWhenRaceCannotStartWithLessThanTwoPlayers()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
            
        [Test]
        public void TestAverageHorsePowerOfRiders()
        {
            string model1 = "Imaha";
            int horsePower1 = 100;
            double cubicCentimeters1 = 150.5;
            var motorcycle1 = new UnitMotorcycle(model1, horsePower1, cubicCentimeters1);

            string model2 = "Imaha2";
            int horsePower2 = 100;
            double cubicCentimeters2 = 150.5;
            var motorcycle2 = new UnitMotorcycle(model2, horsePower2, cubicCentimeters2);

            string name1 = "Ivan1";
            UnitRider rider1 = new UnitRider(name1, motorcycle1);

            string name2 = "Ivan2";
            UnitRider rider2 = new UnitRider(name2, motorcycle2);

            var race = new RaceEntry();
            race.AddRider(rider1);
            race.AddRider(rider2);

            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}