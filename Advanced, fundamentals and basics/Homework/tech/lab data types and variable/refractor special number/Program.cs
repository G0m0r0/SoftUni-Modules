using System;

namespace refractor_special_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool flag = false;
            for (int ch = 1; ch <= number; ch++)
            {
                int  num = ch;
                int sum = 0;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                flag = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", num, flag);
                sum = 0;
                ch = num;
            }
        }
    }
}
