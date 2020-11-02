using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> Repository;

        public StudentSystem()
        {
            this.Repository = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();
            string command = args[0];

            if (command == "Create")
            {
                AddStudent(args);
            }
            else if (command == "Show")
            {
                ShowStudent(args);

            }
            else if (command == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private void ShowStudent(string[] args)
        {            
            var name = args[1];
            if (Repository.ContainsKey(name))
            {
                var student = Repository[name];

                Console.WriteLine(student.ToString());
            }
        }

        private void AddStudent(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            if (!Repository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repository[name] = student;
            }
        }
    }
}

