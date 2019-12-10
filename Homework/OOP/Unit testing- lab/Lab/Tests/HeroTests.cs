using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class HeroTests
    {
      
        [Test]
        public void TestHeroConstructor()
        {
            var name = "Ivan";
            var experience = 0;
            IWeapon axe = new Axe(10, 10);

            var hero = new Hero(name);

            Assert.AreEqual(hero.Name, name);
            Assert.AreEqual(hero.Experience, experience);
            Assert.AreEqual(hero.Weapon.ToString(), axe.ToString());
        }
        [Test]
        public void GainingXpFunctionalityWhenTargetIsDeath()
        {
            var hero = new Hero("Petko");
            var axe = new Axe(100, 1000);
            var dummy = new Dummy(10, 10);

            hero.Attack(dummy);      

            Assert.AreEqual(hero.Experience,10);
        }

        [Test]
        public void TestAttackheroWhenTargetIsNotDead()
        {
            var hero = new Hero("Petko");
            var axe = new Axe(10, 1000);
            var dummy = new Dummy(1000, 10);

            hero.Attack(dummy);

            Assert.AreEqual(hero.Experience, 0);
        }
    }
}
