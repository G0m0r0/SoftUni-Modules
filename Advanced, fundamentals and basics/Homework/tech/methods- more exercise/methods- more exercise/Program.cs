using System;

namespace methods__more_exercise
{
    class Program
    {
        static int Parsing(int num)
        {
            return num * 2;
        }
        static double Parsing(double num)
        {
            return num * 1.5;
        }
        static string Parsing(string str)
        {
            return "$"+str+"$";
        }
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    {
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine(Parsing(num));
                    }break;
                case "real":
                    {
                        double num = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{(Parsing(num)):f2}");
                    }
                    break;
                case "string":
                    {
                        string str = Console.ReadLine();
                        Console.WriteLine(Parsing(str));
                    }break;
             default:
                 break;
         }
        }
    }
}
