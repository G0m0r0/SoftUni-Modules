using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnHelper.Tests
{
    [TestFixture]
    public class EgnInformationExtractorTest
    {
        [Test]
        //6101057509
        //Egn male, born 5 january 1961 year, in region Sofia
        public void ExtractInfomationShouldWorkCorrectlyFor6101057509()
        {
            var informationExtractor = new EgnInformationExtracter();

            EgnInformation information = informationExtractor.Extract("6101057509");

            Assert.That(information.ToString(),Is.EqualTo("Egn male, born 5 january, 1961 year in region Sofia"));
            Assert.That(information.PlaceOfBirth, Is.EqualTo("Sofia"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1961, 1, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
        }

        [Test]
        //8032056031
        //Egn female,born 5 december 1880 year, in region Smolyan
        public void ExtractInfomationShouldWorkCorrectlyFor8032056031()
        {
            var EgnInformationExtractor = new EgnInformationExtracter();

            var information = EgnInformationExtractor.Extract("8032056031");

            Assert.That(information.ToString(), Is.EqualTo("Egn female,born 5 december 1880 year, in region Smolyan"));
            Assert.That(information.PlaceOfBirth, Is.EqualTo("Smolyan"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1880, 12, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Female));
        }

        //7552010005
        //Egn male,born 1 december 2075 year, in region Blagoevgrad
        public void ExtractInfomationShouldWorkCorrectlyFor7552010005()
        {
            var EgnInformationExtractor = new EgnInformationExtracter();

            var information = EgnInformationExtractor.Extract("7552010005");

            Assert.That(information.ToString(), Is.EqualTo("Egn male,born 1 december 2075 year, in region Blagoevgrad"));
            Assert.That(information.PlaceOfBirth, Is.EqualTo("Blagoevgrad"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(205, 12, 1)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
        }

        [Test]
        public void ExtractShouldThrowArgumentException()
        {
            var alwaysFalse = new Mock<IEgnValidator>();
            alwaysFalse.Setup(x => x.IsValid(It.IsAny<string>()))
                .Returns(false);

            var egninformationExtractor = new EgnInformationExtracter(alwaysFalse.Object);

            Assert.Throws<ArgumentException>(() => egninformationExtractor.Extract("0000000000"));

        }
    }
    //insted of moq
   //internal class AlswaysInvalidEgnValidator : IEgnValidator
   //{
   //    public bool IsValid(string egn)
   //    {
   //        return false;
   //    }
   //}
}
