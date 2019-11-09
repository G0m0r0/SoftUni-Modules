using System;

namespace Encapsulation
{
    public class Person
    {
        //private const decimal minSalary= 460m;
        private readonly IMinimalSalaryProvider salarayProvider;
        private readonly int num=100;
        //we can set value in here same as {get;}
        private string name;
        private int age;
        private decimal salary;

        public Person(string name,int age,decimal salary,IMinimalSalaryProvider salaryProvider)
        {
            this.salarayProvider = salaryProvider;
            num = 500;
            this.Age = age;
            this.name = name;
            this.Salary = salary;            
        }

        public decimal Salary
        {
            get => salary;
            set
            {
                if(value<this.salarayProvider.GetMinimalSalary())
                {
                    throw new ArgumentOutOfRangeException(nameof(value),$"Salaray must be at least {this.salarayProvider.GetMinimalSalary()}");
                }
            }            
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


        public void IncreaseSalary(decimal percent)
        {
            if(this.age<30)
            {
                percent /= 2;
            }

            this.salary *= 1 + (percent / 100.0m);
        }
    }
}
