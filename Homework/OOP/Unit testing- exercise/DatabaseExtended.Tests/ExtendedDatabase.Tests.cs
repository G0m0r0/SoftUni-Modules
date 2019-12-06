using ExtendedDatabase;
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
        public void ValidRangeOfMaxPeople()
        {
            var array = new Person[16]
            {
                new Person(1,"ivan1"),
                 new Person(2,"ivan2"),
                 new Person(3,"ivan3"),
                 new Person(4,"ivan4"),
                 new Person(5,"ivan5"),
                 new Person(6,"ivan6"),
                 new Person(7,"ivan7"),
                 new Person(8,"ivan8"),
                 new Person(9,"ivan9"),
                 new Person(10,"ivan10"),
                 new Person(11,"ivan11"),
                 new Person(12,"ivan12"),
                 new Person(13,"ivan13"),
                 new Person(14,"ivan14"),
                 new Person(15,"ivan15"),
                 new Person(16,"ivan16"),
            };
            var ExtendedDatabasee = new ExtendedDatabasee(array);

            int expectedCount = 16;
            int actualCount = ExtendedDatabasee.Count;

            Assert.IsTrue(expectedCount == actualCount);
        }
        [Test]
        public void RangeIsHigherThanAwolled()
        {
            var array = new Person[17]
            {
                new Person(1,"ivan1"),
                 new Person(2,"ivan2"),
                 new Person(3,"ivan3"),
                 new Person(4,"ivan4"),
                 new Person(5,"ivan5"),
                 new Person(6,"ivan6"),
                 new Person(7,"ivan7"),
                 new Person(8,"ivan8"),
                 new Person(9,"ivan9"),
                 new Person(10,"ivan10"),
                 new Person(11,"ivan11"),
                 new Person(12,"ivan12"),
                 new Person(13,"ivan13"),
                 new Person(14,"ivan14"),
                 new Person(15,"ivan15"),
                 new Person(16,"ivan16"),
                 new Person(17,"ivan17"),
            };

            Assert.Throws<ArgumentException>(() => new ExtendedDatabasee(array));
        }

        [Test]
        public void RangeIsUnderZero()
        {
            //TODO: if possible
        }
        [Test]
        public void AddMorePersonsThanTheSizw()
        {
            var array = new Person[16]
            {
                new Person(1,"ivan1"),
                 new Person(2,"ivan2"),
                 new Person(3,"ivan3"),
                 new Person(4,"ivan4"),
                 new Person(5,"ivan5"),
                 new Person(6,"ivan6"),
                 new Person(7,"ivan7"),
                 new Person(8,"ivan8"),
                 new Person(9,"ivan9"),
                 new Person(10,"ivan10"),
                 new Person(11,"ivan11"),
                 new Person(12,"ivan12"),
                 new Person(13,"ivan13"),
                 new Person(14,"ivan14"),
                 new Person(15,"ivan15"),
                 new Person(16,"ivan16"),
            };
            var database = new ExtendedDatabasee(array);

            var person = new Person(17, "Ivan17");
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "Ivan17")));
        }

        [Test]
        public void ExceptionThereIAlreadyUserWithThisUsername()
        {
            var array = new Person[1]
           {
                new Person(1,"Ivan1"),
           };
            var database = new ExtendedDatabasee(array);

            var person = new Person(2, "Ivan1");
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }
        [Test]
        public void ExceptionThereISUserWithThisId()
        {
            var array = new Person[1]
           {
                new Person(1,"ivan1"),
           };
            var database = new ExtendedDatabasee(array);

            var person = new Person(1, "Ivan100");
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void ValidAddPerson()
        {
            var array = new Person[1]
           {
                new Person(1,"Ivan1"),
           };
            var database = new ExtendedDatabasee(array);
            var person = new Person(2, "Ivan2");
            database.Add(person);

            var expectedCount = 2;
            var resultCount = database.Count;

            Assert.IsTrue(expectedCount == resultCount);
        }

        [Test]
        public void RemovePersonWhenDatabaseIsEmpty()
        {
            var database = new ExtendedDatabasee();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void ValidRemoveData()
        {
            var array = new Person[1]
          {
                new Person(1,"Ivan1"),
          };
            var database = new ExtendedDatabasee(array);
            database.Remove();

            Assert.IsTrue(database.Count == 0);
        }

        [Test]
        public void ThereIsNoValidUsernameBecauseOfEmptySpace()
        {
            var array = new Person[1]
          {
                new Person(1,"Ivan1"),
          };
            var database = new ExtendedDatabasee(array);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void ThereIsNoFoundUserInTheDatabase()
        {
            var array = new Person[1]
          {
                new Person(1,"Ivan1"),
          };
            var database = new ExtendedDatabasee(array);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Iva46346n2"));
        }

        [Test]
        public void ValidOperationForFindingPeople()
        {
            var array = new Person[1]
            {
                new Person(1,"Ivan1")
            };
            var database = new ExtendedDatabasee(array);

            Assert.AreEqual(database.FindByUsername("Ivan1"), array[0]);
        }

        [Test]
        public void IdLenghtIsNegativeNumber()
        {
            long id = -1;
            var database = new ExtendedDatabasee();

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void ThereIsNoUserByTheGivenId()
        {
            var array = new Person[1]
                { new Person(1, "Ivan1") };

            var database = new ExtendedDatabasee(array);
            var randomId = 200000;

            Assert.Throws<InvalidOperationException>(() => database.FindById(randomId));
        }

        [Test]
        public void ValidOperationForFindingById()
        {
            var array = new Person[1]
            {
                new Person(1,"Ivan1")
            };

            var database = new ExtendedDatabasee(array);
            var ivansId = 1;

            var foundPerson = database.FindById(ivansId);

            Assert.AreEqual(foundPerson, array[0]);
        }
    }
}