using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            //third if payable (ascii letters in money)/kg
           int catchedFish = int.Parse(Console.ReadLine());
            string nameFish = Console.ReadLine();
            double money = 0;
            char letter = ' ';
            while(nameFish=="stop")
            {
                for (int i = 0; i <nameFish.Length; i++)
                {
                    letter = nameFish[nameFish.Length - 1];
                    nameFish = nameFish.Remove(nameFish.Length - 1);
                    Console.WriteLine(letter);
                }
            }
        }
    }
}
