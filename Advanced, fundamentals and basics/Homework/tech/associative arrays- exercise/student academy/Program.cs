using System;
using System.Collections.Generic;
using System.Linq;

namespace student_academy
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentInfo = new Dictionary<string, List<double>>();
            int pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairs; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(!studentInfo.ContainsKey(name))
                {
                    studentInfo[name] = new List<double> { grade };
                }
                else
                {
                    studentInfo[name].Add(grade);
                }
            }

            foreach (var kvp in studentInfo.Where(x=>x.Value.Average()>=4.5).OrderByDescending(x=>x.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {(kvp.Value.Average()):f2}");
            }
        }
    }
}
