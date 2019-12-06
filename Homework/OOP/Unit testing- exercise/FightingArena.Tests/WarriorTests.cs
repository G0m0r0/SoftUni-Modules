using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int minimumHpForAttack= 30;
        [Test]
        public void TestConstructorIsItTakesCorrectProperties()
        {
            var name = "Ivan";
            var damage = 100;
            var hp = 1000;

            var warrior = new Warrior(name, damage, hp);

            Assert.IsTrue(name == warrior.Name);
            Assert.IsTrue(damage == warrior.Damage);
            Assert.IsTrue(hp == warrior.HP);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestIfNameIsNullOrWhiteSpace(string name)
        {
            var damage = 100;
            var hp = 1000;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(-25235623)]
        public void TestIfDamageIsNegative(int damage)
        {
            var name = "Ivan";
            var hp = 100;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-25235623)]
        public void TestIfHPIsNegative(int hp)
        {
            var name = "Ivan";
            var damage = 100;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void ThrowExceptionForAttackingUnderMinimumHP()
        {
            var name = "Ivan";
            var damage = 100;
            var hp = 10;

            var warrior = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
        }

      //[Test]
      //public void ThrowExceptionForAttackingEnemyUnderMinimumHP()
      //{
      //    var name = "me";
      //    var damage = 10;
      //    var hp = 100;
      //
      //    var warrior = new Warrior(name, damage, hp);
      //
      //    Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
      //}
    }
}