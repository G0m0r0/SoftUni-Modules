using System;

namespace poke_mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int storage = n;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int br = 0;
            while (m <= n)
            {
                n -= m;
                br++;
                if (storage / 2 == n)
                    if(y>0)
                    n = n / y;
            }
            Console.WriteLine(n);
            Console.WriteLine(br);
        }
    }
}
