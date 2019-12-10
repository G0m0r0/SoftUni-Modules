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
        public void ThrowExceptionForAttackingUnderMinimumHPFirstWorrior()          
        {
            var warrior1 = new Warrior("Ivan1", 10, 10);
            var warrior2 = new Warrior("Ivan2", 50, 50);
            //Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(5.2, result.RealPart, "Real part");
            //    Assert.AreEqual(3.9, result.ImaginaryPart, "Imaginary part");
            //});
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
        [Test]
        public void ThrowExceptionForAttackingUnderMinimumHPSecondWorrior()
        {
            var warrior1 = new Warrior("Ivan1", 50, 50);
            var warrior2 = new Warrior("Ivan2", 50, 10);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void TestIfWorriorFirstHpIsLessThanWorriorHpSecond()
        {
            var warrior1 = new Warrior("Ivan1", 50, 50);
            var warrior2 = new Warrior("Ivan2", 500, 50);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void ValidAttackTest()
        {
            var warrior1 = new Warrior("Ivan1", 50, 5000);
            var warrior2 = new Warrior("Ivan2", 500, 50);

            warrior1.Attack(warrior2);
            var expectedHP = 4500;
            var warrior1HP = warrior1.HP;

            Assert.IsTrue(expectedHP == warrior1HP);
        }
        [Test]
        public void ValidAttackTestSecondWorriorIfFirstWarriorHaveMoreDamage()
        {
            var warrior1 = new Warrior("Ivan1", 60, 5000);
            var warrior2 = new Warrior("Ivan2", 500, 50);

            warrior1.Attack(warrior2);
            var expectedHP = 0;
            var warrior2HP = warrior2.HP;

            Assert.IsTrue(expectedHP == warrior2HP);
        }

        [Test]
        public void ValidAttackTestSecondWorriorIfSecondWorrierHaveMoreHp()
        {
            var warrior1 = new Warrior("Ivan1", 40, 5000);
            var warrior2 = new Warrior("Ivan2", 500, 50);

            warrior1.Attack(warrior2);
            var expectedHP = 10;
            var warrior2HP = warrior2.HP;

            Assert.IsTrue(expectedHP == warrior2HP);
        }
    }
}