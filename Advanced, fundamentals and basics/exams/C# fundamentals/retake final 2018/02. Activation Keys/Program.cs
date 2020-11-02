using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().ToUpper().Split("&").ToList();
            ValidInput(input);

            InputDashes(input);

            input = SubstractDigit(input).Split("&").ToList();

            Console.WriteLine(string.Join(", ",input));
        }

        private static string SubstractDigit(List<string> input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join("&", input));
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsDigit(sb[i]))
                {
                    int value = Math.Abs(int.Parse(sb[i].ToString()) - 9);
                    sb[i] = char.Parse(value.ToString());
                }
            }
            return sb.ToString();
        }

        private static void InputDashes(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = InsertDashes(input[i]);
            }
        }

        private static string InsertDashes(string word)
        {
            if (word.Length == 16)
            {
                int lenght = word.Length;
                for (int i = 4; i < lenght; i += 4)
                {
                    word = word.Insert(i++, "-");
                    lenght++;
                }
            }
            else
            {
                int lengh = word.Length;
                for (int i = 5; i < lengh; i += 5)
                {
                    word = word.Insert(i++, "-");
                    lengh++;
                }
            }
            return word;
        }

        private static void ValidInput(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length != 16 && input[i].Length != 25)
                {
                    input.RemoveAt(i--);
                    //continue;
                }
                if (CheckLetters(input[i]))
                {
                    input.RemoveAt(i--);
                }
            }
        }

        private static bool CheckLetters(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] < 65 || word[i] > 90)
                        if (word[i] < 48 || word[i] > 57)
                            return true;
            }
            return false;
        }
    }
}
