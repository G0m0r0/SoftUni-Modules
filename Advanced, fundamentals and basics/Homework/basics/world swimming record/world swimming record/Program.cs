using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace world_swimming_record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldrecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());
            
     
            double allTimeSeconds = meters * timeForMeter + Math.Floor(meters / 15) * 12.5;
            
            if (allTimeSeconds<worldrecord) Console.WriteLine($"Yes, he succeeded! The new world record is {(allTimeSeconds):F2} seconds.");

            else
            {
                Console.WriteLine($"No, he failed! He was {(allTimeSeconds - worldrecord):F2} seconds slower.");

            }
        }
    }
}
