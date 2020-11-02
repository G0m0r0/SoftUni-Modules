using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentsDatabase
    {
        private Dictionary<string, Student> Repository { get; set; }

        public StudentsDatabase()
        {
            this.Repository = new Dictionary<string, Student>();
        }

        public void Add(string name,int age, double grade)
        {
            if (!Repository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repository[name] = student;
            }
        }

        public Student Find(string name)
        {
            if (this.Repository.ContainsKey(name))
            {
                return this.Repository[name];

            }
            return null;
        }
    }
}
