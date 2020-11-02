using System;
using System.Text;

namespace _6.Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(sequence);
            for (int i = 1; i < sb.Length; i++)
            {
                if (sb[i-1] == sb[i])
                    sb.Remove(i--, 1);
            }
            Console.WriteLine(sb);
        }
    }
}