using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DummyTests
    {

        private static Dummy InitializeDummy(int health,int exp)
        {
            return new Dummy(health, exp);
        }
        [Test]
        public void DummyLoosesHelathIfHeIsAttacked()
        {
            var experience = 10;
            var health = 10;
            var dummy = InitializeDummy(health, experience);
            dummy.TakeAttack(1);

            Assert.IsTrue(dummy.Health == 9,"Health should be 9");
        }

        [Test]
        public void DummyIsDyingThrowException()
        {
            var experience = 10;
            var health = 0;
            var dummy = InitializeDummy(health, experience);

            Assert.Throws<InvalidOperationException>(()=>dummy.TakeAttack(5),"Dummy should be death");
        }

        [Test]
        public void DeadDummyCanGiveEXP()
        {
            var experience = 20;
            var health = 0;
            var dummy = InitializeDummy(health, experience);

            Assert.IsTrue(dummy.GiveExperience()==experience,"Dummy should give exp");
        }

        [Test]
        public void AliveDummyCannotGiveEXP()
        {
            var experience = 20;
            var health = 10;
            var dummy = InitializeDummy(health, experience);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException,"Dummy shouldnt give exp");
        }
    }
}
