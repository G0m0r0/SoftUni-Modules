namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
       [Test]
       public void Testconstructor()
        {
            int capacity = 10;
            string name = "IvanStation";
            var spaceShip = new Spaceship(name,capacity);

            Assert.AreEqual(spaceShip.Name, name);
            Assert.AreEqual(spaceShip.Capacity, capacity);
       }

        [TestCase("")]
        [TestCase(null)]
        public void TestwhenNameIsnNullO(string nameToTest)
        {
            int capacity = 10;
           
            Assert.Throws<ArgumentNullException>(()=>new Spaceship(nameToTest, capacity));
        }
         
        [TestCase(-1000)]
        [TestCase(-1)]
        public void TestArgumentExceptionForNegativeCapacity(int capacity)
        {
            string name = "IvanSpaceShip";

            Assert.Throws<ArgumentException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void TestWhenSpaceShipIsFull()
        {
            int capacity = 2;
            string name = "IvanStation";
            var spaceShip = new Spaceship(name, capacity);

            spaceShip.Add(new Astronaut("Ivan1", 10.5));
            spaceShip.Add(new Astronaut("Ivan2", 11.5));

            Assert.Throws<InvalidOperationException>(() => spaceShip.Add(new Astronaut("Ivan3", 10.6)));
        }

        [Test]
        public void TestWhenAstronautIsAlreadyIn()
        {
            int capacity = 10;
            string name = "IvanStation";
            var spaceShip = new Spaceship(name, capacity);

            spaceShip.Add(new Astronaut("Ivan1", 10.5));
            spaceShip.Add(new Astronaut("Ivan2", 11.5));

            Assert.Throws<InvalidOperationException>(() => spaceShip.Add(new Astronaut("Ivan2", 10.6)));
        }

        [Test]
        public void SuccessfulAddAstronaut()
        {
            int capacity = 10;
            string name = "IvanStation";
            var spaceShip = new Spaceship(name, capacity);

            spaceShip.Add(new Astronaut("Ivan1", 10.5));
            spaceShip.Add(new Astronaut("Ivan2", 11.5));

            Assert.AreEqual(spaceShip.Count, 2);
        }

        [Test]
        public void RemoveAstronaut()
        {
            int capacity = 10;
            string name = "IvanStation";
            var spaceShip = new Spaceship(name, capacity);

            spaceShip.Add(new Astronaut("Ivan1", 10.5));
            spaceShip.Add(new Astronaut("Ivan2", 11.5));

            spaceShip.Remove("Ivan1");

            Assert.AreEqual(spaceShip.Count, 1);           
        }
    }
}