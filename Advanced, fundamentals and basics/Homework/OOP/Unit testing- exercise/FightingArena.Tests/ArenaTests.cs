using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        [Test]
        public void TestInitializeConstructor()
        {
            var arena = new Arena();
            Assert.AreEqual(arena.Warriors, new List<Warrior>());
        }

        [Test]
        public void TestIfreturnCountIsValid()
        {
            var arena = new Arena();

            var expectedCount = 0;
            var resultCount = arena.Count;

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void EnrollAlreadyErolledWarrior()
        {
            var arena = new Arena();

            var warrrior = new Warrior("Ivan", 100, 1000);
            arena.Enroll(warrrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrrior));
        }

        [Test]
        public void TestIfArenaAddsWorriorsCorrectly()
        {
            var arena = new Arena();
            var warrior = new Warrior("ivan", 100, 1000);

            arena.Enroll(warrior);

            var expectedCount = 1;
            var resultCount = arena.Count;

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public void DefendersNameIsNull()
        {
         // var arena = new Arena();
         // var warriorDefender = new Warrior(null, 10, 100);
         // var warriorAttacker = new Warrior("Ivan", 10, 10);
         //
         // arena.Enroll(warriorAttacker);
        }

        //TODO: validate if attacker or defender's name are null
    }
}
