using System;

namespace perfect_volume_of_pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
           double lenght = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
           double width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
           double height = double.Parse(Console.ReadLine());

           double V = (lenght * width*height )/3;
            Console.Write($"Pyramid Volume: {V:f2}");

        }
    }
}
