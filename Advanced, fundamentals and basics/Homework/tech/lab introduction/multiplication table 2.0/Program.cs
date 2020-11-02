using System;

namespace multiplication_table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplayer = int.Parse(Console.ReadLine());
            if (multiplayer > 10) Console.WriteLine(num+" X "+multiplayer+ " = "+num*multiplayer);
            else for (int i = multiplayer; i <=10; i++)
                {
                    Console.WriteLine(num + " X " + i + " = " + num * i);
                }

        }
    }
}
