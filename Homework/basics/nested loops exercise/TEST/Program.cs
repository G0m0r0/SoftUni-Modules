using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            // int num = int.Parse(Console.ReadLine());
            // int n = 0;
            // for (int i = 0; i < 4; i++)
            // {
            //     n = num % 10;
            //     Console.WriteLine(n);
            // }
            string nameFish = Console.ReadLine();
            for (int i = 0; i <nameFish.Length; i++)
            {
                int letter = ' ';
                letter = nameFish[nameFish.Length-1];
                nameFish = nameFish.Remove(nameFish.Length - 1);
                Console.WriteLine(letter);
            }
            Console.ReadLine();
        }
    }
}
