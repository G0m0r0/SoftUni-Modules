using System;
using System.Collections.Generic;
using System.Linq;

namespace students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                Student student = new Student();

                if(IsStudentExisting(students,command[0],command[1]))
                {
                    student = GetStudent(students, command[0], command[1]);

                    student.firstName = command[0];
                    student.lastName = command[1];
                    student.age = int.Parse(command[2]);
                    student.hometown = command[3];
                }
                else
                {
                    student.firstName = command[0];
                    student.lastName = command[1];
                    student.age = int.Parse(command[2]);
                    student.hometown = command[3];
                }

                students.Add(student);
                command = Console.ReadLine().Split().ToArray();
            }
            string cityName = Console.ReadLine();
            foreach (var item in students)
            {
                if (cityName == item.hometown)
                    Console.WriteLine($"{item.firstName} {item.lastName} is {item.age} years old.");
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existing = null;
            foreach (Student item in students)
            {
                if(item.firstName==firstName&&item.lastName==lastName)
                {
                    existing = item;
                }
            }
            return existing;
        }

        private static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student item in students)
            {
                if(item.firstName==firstName&&item.lastName==lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string hometown { get; set; }
    }
}