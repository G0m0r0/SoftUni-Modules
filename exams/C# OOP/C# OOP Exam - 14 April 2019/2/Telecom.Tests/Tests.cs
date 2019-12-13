namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            string make = "Iphone";
            string model = "10";

            var phone = new Phone(make, model);

            Assert.AreEqual(phone.Make, make);
            Assert.AreEqual(phone.Model, model);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakePropertyIsNullAndEmpty(string make)
        {
            string model = "10";

            Assert.Throws<ArgumentException>(()=>new Phone(make, model));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelPropertyIsNullAndEmpty(string model)
        {
            string make = "Iphone";

            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }

        [Test]
        public void TestInvalidOperationForAddingExistingContact()
        {
            var phone = new Phone("Iphone", "10");

            var nameContact = "Ivan1";
            var phoneNumber = "1234567";
            phone.AddContact(nameContact, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(nameContact, phoneNumber));
        }

        [Test]
        public void TestIfaddingContactWorkCorrectly()
        {
            var phone = new Phone("Iphone", "10");

            var nameContact = "Ivan1";
            var phoneNumber = "1234567";
            phone.AddContact(nameContact, phoneNumber);

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void CallPersonThatDoesntExcist()
        {
            var phone = new Phone("Iphone", "10");

            var nameContact = "Ivan1";

            Assert.Throws<InvalidOperationException>(() => phone.Call(nameContact));
        }
            
        [Test]
        public void SuccessfullCall()
        {
            var phone = new Phone("Iphone", "10");

            var nameContact = "Ivan1";
            var phoneNumber = "1234567";
            phone.AddContact(nameContact, phoneNumber);

            Assert.AreEqual($"Calling {nameContact} - {phoneNumber}...", phone.Call(nameContact));
        }
    }
}