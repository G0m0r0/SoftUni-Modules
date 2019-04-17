using System;

namespace characters_in_range
{
    class Program
    {
        static void Swap(ref char a,ref char b)
        {
            char parse = a;
            a =b;
            b = parse;
        }
        static void CharInRange(char a,char b)
        {
            if (a > b)
                Swap(ref a, ref b);

            for (char i = ++a; i <b ; i++)
            {
                Console.Write(i+" ");
            }
        }
        static void Main(string[] args)
        {
            char a =char.Parse( Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            CharInRange(a, b);
        }
    }
}
