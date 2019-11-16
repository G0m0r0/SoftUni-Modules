using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Person : ICitizen
    {
        public Person(string name,int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
        public string Name { get;  }
        public int Age { get;  }

        public string ID { get; }
    }
}
