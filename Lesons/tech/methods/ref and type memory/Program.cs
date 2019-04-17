using System;
using System.Text;

namespace ref_and_type_memory
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = a;
            a = 6; //if we change a only a is change
            Console.WriteLine(b);

            int[] c = new int[2] { 1, 2 };
            int[] d = c;
            d[0] = 101; //if we change d both are changed
            Console.WriteLine(c[0]);

            string e = "asd";
            string f = e;
            e = e + "niki";
            //we cant change string
            Console.WriteLine(e);

            //using System.text;

        }
    }
}
