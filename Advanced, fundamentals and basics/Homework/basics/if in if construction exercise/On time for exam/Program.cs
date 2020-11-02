using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_time_for_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int arrivingHour = int.Parse(Console.ReadLine());
            int arrivingMinutes = int.Parse(Console.ReadLine());

            int timeExam = hours * 60 + minutes;
            int arrivingTime = arrivingHour * 60 + arrivingMinutes;
            int minDifference= arrivingTime - timeExam;

            if (minDifference < -30) Console.WriteLine("Early");
            else if (minDifference <= 0) Console.WriteLine("On time");
            else Console.WriteLine("Late");

            int finalHours = Math.Abs(minDifference / 60);
            int finalMinutes = Math.Abs(minDifference % 60);

            if(finalHours>0)
            if (finalMinutes<10)
            {
                Console.Write(finalHours+":0"+finalMinutes+" hours");
            }
            else Console.Write(finalHours+":"+finalMinutes+"hours");
            else Console.Write(finalMinutes+"minutes");
            if (minDifference<0)
            {
                Console.WriteLine(" before the start");
            }
            else Console.WriteLine(" after the start");
        } 
    }
}
