using System;

namespace grades
{
    class Program
    {
        static string GradeSystem(double grade)
        {
            if (grade >= 5.5&&grade<=6) return "Excellent";
            else if (grade >= 4.5) return "Very good";
            else if (grade >= 3.5) return "Good";
            else if (grade >= 3) return "Poor";
            else if (grade >= 2) return "Fail";
            return "Invalid grade";
        }
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Console.WriteLine(GradeSystem(grade));
        }
    }
}
