using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> recordDictionarie = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] student = Console.ReadLine().Split().ToArray();
                string name = student[0];
                double grade = double.Parse(student[1]);

                if(!recordDictionarie.ContainsKey(name))
                {
                    recordDictionarie[name] = new List<double>();
                }

                recordDictionarie[name].Add(grade);
            }

            foreach (var kvp in recordDictionarie)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (var item in kvp.Value)
                {
                    Console.Write($"{item:f2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
