using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_condition
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int hoursAndMinutes = (hours * 60) + minutes + 15;
            int newHours = hoursAndMinutes / 60;
            if (newHours > 23) newHours = 1;
            int newMinutes = hoursAndMinutes % 60;
            string newHourString,newMinuteString;
            
            if (newHours < 10)  newHourString = 0 + Convert.ToString(newHours); 
            else newHourString = Convert.ToString(newHours);
            if (newMinutes < 10) newMinuteString = 0 + Convert.ToString(newMinutes);
            else newMinuteString=Convert.ToString(newHours);
            Console.WriteLine($"{newHourString}:{newMinuteString}");



        }
    }
}
