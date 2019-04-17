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
            for (int i = 0; i < sb.Length-1; i++)
            {
                if (sb[i] == sb[i + 1])
                    sb.Remove(i--, 1);
            }
            Console.WriteLine(sb);
        }
    }
}
