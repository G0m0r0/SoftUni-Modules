using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnHelper.Tests
{
    //[SetUp]
    //before execusion

    //[TearDown]
    //after execusion

    [TestFixture]
    public class EgnValidatorTests
    {
        [TestCase("6101057509")]
        [TestCase("643634")]
        public void ValidateMethodShouldBeTurnTrueForValidEgn_ForManytests(string egn)
        {
            //arrange
            var validate = new EgnValidator();
            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
            //act
            var result = validate.IsValid(egn);

            //exceptions
            Assert.That(() => validate.IsValid(null), Throws.ArgumentNullException);
            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
            //Assert
            Assert.IsTrue(result);
        }
        [TestCase]
        public void ValidateMethodShouldBeTurnTrueForValidEgn_ForOneTest()
        {
            //arrange
            var validate = new EgnValidator();
            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
            //act
            var result = validate.IsValid("6101057509");

            //exceptions
            Assert.That(() => validate.IsValid(null), Throws.ArgumentNullException);
            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
            //Assert
            Assert.IsTrue(result);
        }
    }
}
