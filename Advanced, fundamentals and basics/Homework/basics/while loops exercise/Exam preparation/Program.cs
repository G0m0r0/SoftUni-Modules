using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxBadGrades = int.Parse(Console.ReadLine());
           string operation = " ";
            int grade = 0;
            int badMark = 0;
            double sumGrades = 0;
            int i = 0;
            string lastOperation = " ";
           while(badMark<maxBadGrades)
            {
                operation = Console.ReadLine();
                if (operation == "Enough")
                {
                    Console.WriteLine($"Average score: {(sumGrades / i):f2}");
                    Console.WriteLine($"Number of problems: {i}");
                    Console.WriteLine($"Last problem: {lastOperation}");
                    break;
                }
                grade = int.Parse(Console.ReadLine());
                if (grade <= 4) badMark++;
                sumGrades += grade;
                i++;
                lastOperation = operation;
            }
          
           if (badMark >= maxBadGrades) Console.WriteLine($"You need a break, {badMark} poor grades.");
        }
    }
}
