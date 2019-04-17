using System;

namespace back_in_30_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            b += 30;
            if(b>60)
            {
                a++;
                b -= 60;
            }
            if(a>=24)
            {
                a -= 24;
            }
            DateTime time = new DateTime(2008, 1, 1, a, b, 1);
           if(a<10) Console.WriteLine(time.ToString("H:mm"));
            else Console.WriteLine(time.ToString("HH:mm"));
        }
    }
}
