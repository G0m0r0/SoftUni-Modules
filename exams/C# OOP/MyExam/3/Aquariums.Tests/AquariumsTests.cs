namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void TestConstructor()
        {
            string name = "Ivan";
            int capacity = 10;

            var aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestWhenNameISNullOrWhityeSpace(string name)
        {
            var capacity = 10;

            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void TestWhenCapacityIsNegative()
        {
            string name = "Ivan";
            int capacity = -10;

            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void TestWhenAquariumIsFull()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void TestSuccessfullAddingFish()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void FishToRemoveDoesntExist()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);


            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Penlka"));
        }

        [Test]
        public void TestSeccessfulRemovingFish()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);
            aquarium.Add(fish);

            aquarium.RemoveFish(fishName);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void TestSellingFishWithIncorrectName()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Penka"));
        }
        [Test]
        public void SuccessfulSellingFish()
        {
            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);
            aquarium.Add(fish);

            var SoldFish = aquarium.SellFish(fishName);

            Assert.AreEqual(SoldFish, fish);
        }

        [Test]
        public void TestReportFish()
        {
            //string fishNames = string.Join(", ", this.fish.Select(f => f.Name));
            //string report = $"Fish available at {this.Name}: {fishNames}";
            //
            //return report;

            string name = "Ivan";
            int capacity = 1;

            var aquarium = new Aquarium(name, capacity);

            var fishName = "Pesho";
            var fish = new Fish(fishName);
            aquarium.Add(fish);

            Assert.AreEqual($"Fish available at {name}: { fishName}", aquarium.Report());
        }
    }
}
