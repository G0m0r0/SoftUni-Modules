using MyTestingframework.Asserts;
using MyTestingframework.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [MyTestFixture]
    public class PersonTest
    {
        [MyTest]
        public void Test1()
        {
            var person1 = new Person();
            var person2 = new Person();

            MyAssert.AreEqual(person1.Age,person2.Age);
        }
    }
}
