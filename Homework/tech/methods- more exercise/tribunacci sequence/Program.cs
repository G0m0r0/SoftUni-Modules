using System;

namespace tribunacci_sequence
{
    class Program
    {
        static void TribunachiSequence(int num)
        {
            int a = 1;
            int b = 1;
            int c = 2;
            if (num == 1)
            {
                Console.WriteLine("1");
                return;
            }
            else if(num==2)
            {
                Console.WriteLine("1 1");
                return;
            }
            else if(num>=3)
            {
                Console.Write("1 1 2 ");
            }     
            for (int i = 0; i < num-3; i++)
            {
                int lastNum = a + b + c;
                a = b;
                b = c;
                c = lastNum;
                Console.Write(lastNum+" ");
            }

        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            TribunachiSequence(num);
        }
    }
}
