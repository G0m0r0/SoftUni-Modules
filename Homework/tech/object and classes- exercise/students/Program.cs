using System;
using System.Collections.Generic;
using System.Linq;

namespace students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                Student student = new Student(input[0], input[1], double.Parse(input[2]));

                students.Add(student);
            }
            students = students.OrderBy(x => x.Grade).ToList();
            students.Reverse();
            foreach (var item in students)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {(item.Grade):f2}");
            }
        }

    }
    class Student
    {
        public Student(string firsName, string lastName, double grade)
        {
           FirstName = firsName;
           LastName = lastName;
           Grade = grade;
       }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double Grade { set; get; }
    }
}
