using System;

namespace Encapsulation
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name,int age)
        { 
            this.Age = age;
            this.name = name;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value<0)
                {
                    throw new ArgumentOutOfRangeException("Invalid Age");
                }

                this.age = value;
            }                
        }
    
        public string Name
        {
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Invalid name");
                }

                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Name should start with upper letter!");
                }
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }

        public void StartSchool(School school)
        {
            //school.Student.Add(this);
        }
        public void ReportAge(School school)
        {
            Console.WriteLine(this.Age);
        }
    }
}
