using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_prime_non_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int newNum = 0;
            int sumPrime = 0,sum=0;
            bool flag = true;
            while (num!="stop")
            {
                if (int.Parse(num) < 0)
                {
                    Console.WriteLine("Number is negative.");
                    num = Console.ReadLine();
                    continue;
                }
                else if (num == "stop") break;
                else newNum = int.Parse(num);
                int x = (int)Math.Floor(Math.Sqrt(newNum));
                if (newNum == 1) flag = false;
                if (newNum == 2) flag = true;
                for (int i = 2; i <=x; i++)
                {
                    if (newNum % i == 0) flag = false;
                }
                if (flag==true) sumPrime += newNum;
                else sum += newNum;
                num = Console.ReadLine();
                flag = true;        
            }
            Console.WriteLine("Sum of all prime numbers is: {0}",sumPrime);
            Console.WriteLine("Sum of all non prime numbers is: {0}",sum);
        }
    }
}
