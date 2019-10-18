using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClassses
{
    public class Person
    {
        private string name;
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }
}
