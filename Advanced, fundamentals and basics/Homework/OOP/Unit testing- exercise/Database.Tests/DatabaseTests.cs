using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseeTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ConstructorShouldBeInitializeWith16Elements()
        {
            var array = new int[16];
            var ExtendedDatabasee = new Databasee(array);

            int expectedCount = 16;
            int actualCount = ExtendedDatabasee.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void ArraySizeLengthTestIfNotValid()
        {
            int arrayLenght = 17;
            Assert.Throws<InvalidOperationException>(() => new Databasee(new int[arrayLenght]));
        }
        [Test]
        public void NotValidAddOperationToArray()
        {
            var arrayLenght = 16;
            var array = new int[arrayLenght];
            var ExtendedDatabasee = new Databasee(array);

            Assert.Throws<InvalidOperationException>(() => ExtendedDatabasee.Add(5));
        }
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(100000)]
        public void ValidOperataionAddToArray(int elementToAdd)
        {
            var arrayLenght = 10;
            var array = new int[arrayLenght];
            var ExtendedDatabasee = new Databasee(array);

            ExtendedDatabasee.Add(elementToAdd);
            Assert.IsTrue(ExtendedDatabasee.Count == 11);
        }

        [Test]
        public void RemoveElementFromEmptyArray()
        {
            var ExtendedDatabasee = new Databasee();

            Assert.Throws<InvalidOperationException>(() => ExtendedDatabasee.Remove());
        }
        [Test]
        public void ValidRemoveOperation()
        {
            //add only one element and then remove it
            var ExtendedDatabasee = new Databasee(5);

            ExtendedDatabasee.Remove();
            Assert.AreEqual(ExtendedDatabasee.Count, 0);
        }
        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            int[] array = { 1, 2, 3 };
            var ExtendedDatabasee = new Databasee(array);
            ExtendedDatabasee.Remove();

            int expected = 2;
            int actualCount = ExtendedDatabasee.Count;

            Assert.AreEqual(expected, actualCount);
        }
            

        [Test]
        public void TestConstructorTakingOnlyIntegers()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 11, 12, 13, 14, 15 };
            var ExtendedDatabasee = new Databasee(array);
            //Assert.IsTrue(()=>new ExtendedDatabasee(array))
        }

        [Test]
        public void TestIfFetchReturnArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            var ExtendedDatabasee = new Databasee(array);
            ExtendedDatabasee.Add(6);

            int expectedResult = 6;
            int result = ExtendedDatabasee.Fetch()[5];

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsAsArray()
        {
            int[] array = { 1, 5, 2, 4, 5 };
            var ExtendedDatabasee = new Databasee(array);

            int[] expectedValues = { 1, 5, 2, 4, 5 };
            int[] actualValues = ExtendedDatabasee.Fetch();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}