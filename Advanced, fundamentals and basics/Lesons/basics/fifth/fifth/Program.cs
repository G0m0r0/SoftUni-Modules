using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            string firststring = "aaa";
            string secondstring = "bbb";
            string result = firststring + " " + secondstring;
            //we can not substract them but we can concatenate them
            Console.WriteLine(result);
            char fristChar = 'a';
            char secondChar = 'b';
            int result1 = fristChar + secondChar; //it has to be int
            //string result2 = fristChar + secondChar; //it is not possible
            Console.WriteLine(fristChar + secondChar); // from ascii the code of a+b it is equal to 195
            Console.WriteLine((char)result1);
            //Console.WriteLine((char)(fristChar+secondChar));
            //Console.WriteLine((int)2.7); //output= 2
            //if we substract more than the numbers of ascii(256) we start from the begining of ascii
            int a = 5;
            int b = 2;
            int c = 4;
            Console.WriteLine("remainder of devision "+a%b+" from number {0} and {1}",a,b);
            Console.WriteLine("remainder of devision " + b % c+" from numbers {0} and {1}", b, c);
            Console.Read();
        }
    }
}
