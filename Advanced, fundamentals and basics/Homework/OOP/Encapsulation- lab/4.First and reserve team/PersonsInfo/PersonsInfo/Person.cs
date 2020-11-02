using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (this.salary > 460.0m)
                {
                    salary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (this.age > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName.Length >= 3)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");

                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName.Length >= 3)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }



        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
            }

            this.Salary += this.Salary * percentage / 100;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}



