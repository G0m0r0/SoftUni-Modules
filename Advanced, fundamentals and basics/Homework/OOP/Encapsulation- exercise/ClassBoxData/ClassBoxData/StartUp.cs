using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine(box.CalculateSurfaceArea());
                Console.WriteLine(box.CalculateLateralSurface());
                Console.WriteLine(box.CalculateVolume());
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
