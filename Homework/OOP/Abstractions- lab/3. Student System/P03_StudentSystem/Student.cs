namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public override string ToString()
        {
            StringBuilder sbPerson = new StringBuilder();
            sbPerson.Append($"{this.Name} is {this.Age} years old.");

            if (this.Grade >= 5.00)
            {
                sbPerson.Append(" Excellent student.");
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                sbPerson.Append(" Average student.");
            }
            else
            {
                sbPerson.Append(" Very nice person.");
            }

            return sbPerson.ToString();
        }
    }
}
