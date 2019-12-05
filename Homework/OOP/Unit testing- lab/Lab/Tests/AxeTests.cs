using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {

        [Test]
        public void TestIfAxeLoosesDurabilityAfterEachAttack()
        {
            var axe = new Axe(10,10);
            var dummy = new Dummy(10, 10);
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesnt change after attack.");
        }

        [Test]
        public void TestAttackWithBrokenWeapon()
        {
            var axe = new Axe(10, 0);
            var dummy = new Dummy(10, 10);
            //axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(()=>axe.Attack(dummy));
        }
    }
}