using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double a = change * 100;          
            int br=0;
            while(a>=200)
            {
                br++;
                a -= 200;
            }
            while(a>=100)
            {
                br++;
                a -= 100;
            }
            while(a>=50)
            {
                br++;
                a -= 50;
            }
            while(a>=20)
            {
                br++;
                a -= 20;
            }
            while(a>=10)
            {
                br++;
                a -= 10;
            }
            while(a>=5)
            {
                br++;
                a -= 5;
            }
            while(a>=2)
            {
                br++;
                a -= 2;
            }
            while(a>=1)
            {
                br++;
                a -= 1;
            }
            Console.WriteLine(br);
          
         
        }
    }
}
