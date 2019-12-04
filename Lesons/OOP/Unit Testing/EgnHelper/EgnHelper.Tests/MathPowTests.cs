using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnHelper.Tests
{
    [TestFixture]
    public class MathPowTests
    {
        //arrange
        //Act
        //Assert
        [TestCase]
       public void MathPoweShouldWorkCorrectlyForPowerOfTwo()
        {
            var result = Math.Pow(100, 2);
            //Assert
            Assert.AreEqual(10000, result,"Should be 10000!");
            //or
            Assert.That(result,Is.EqualTo(10000));
            //or
            Assert.IsTrue(result == 10000);
            //if(result!=10000)
            //{
            //    throw new Exception("100^2 was excpected!");
            //}

            //if we want it to break
           // Assert.Fail();
        }

        [Test]

        public void GetEnvirment_CurrentDirectoryIsC()
        {
            var directory = Environment.CurrentDirectory;
            Assert.That(directory, Does.Contain(@"D:\"));
        }
    }
}
