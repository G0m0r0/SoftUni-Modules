using System;

namespace intro_more_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if(a<b)
            {
                int swap;
                swap = a;
                a = b;
                b = swap;
            }
            if(c>b)
            {
                int swap;
                swap = c;
                c = b;
                b = swap;
            }
           
            if (a < b)
            {
                int swap;
                swap = a;
                a = b;
                b = swap;
            }
         
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
