using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int a = num % 10; //edinici
            int b = (num / 10) % 10; //desetici
            int c = num / 100; //stotici
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    for (int k = 1; k <= c; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
