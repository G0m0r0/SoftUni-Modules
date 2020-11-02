using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        private string Name;
        private int Age;
        private string Town;

        public Person(string name,int age,string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person otherPerson)
        {
            if(this.Name!= otherPerson.Name)
            {
                return -1;
            }
            if(this.Age!= otherPerson.Age)
            {
                return -1;
            }
            if(this.Town!= otherPerson.Town)
            {
                return -1;
            }
            return 0;
        }
    }
}
