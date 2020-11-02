using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string namePresentaion = Console.ReadLine();
            double finalSum = 0;
            int br = 0;
            double avrMark = 0;
           while(namePresentaion!="finish")
            {
                int i = 0;
                double sum = 0;
                double mark = 0;
                for (i = 1; i <= jury; i++)
                {
                    mark = double.Parse(Console.ReadLine());
                    sum += mark;
                }
                avrMark = Math.Round((sum / (--i)), 2);
                Console.WriteLine($"{namePresentaion} - {avrMark}");
                finalSum += avrMark;
                br++;
                namePresentaion = Console.ReadLine();
            }
            Console.WriteLine("Student's final assessment is {0}",(Math.Round((finalSum/br),2)));
        }
    }
}
