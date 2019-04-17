using System;
using System.Linq;

namespace arrays__more_exercise
{
    class Program
    {
        static int Encrypting(string name)
        {
            char[] nameToCharArray = name.ToCharArray();
            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                switch (nameToCharArray[i].ToString().ToLower())
                {
                    case "a":
                    case "e":
                    case "i":
                    case "o":
                    case "u":
                        sum += nameToCharArray[i] * name.Length;
                        break;
                    default:
                        sum += nameToCharArray[i] / name.Length;
                        break;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int numOfStrings = int.Parse(Console.ReadLine());
            string encryptedNumbers = string.Empty;

            for (int i = 0; i < numOfStrings; i++)
            {
                string names = Console.ReadLine();
               encryptedNumbers+= Encrypting(names)+" ";
            }

            int[] array = encryptedNumbers.Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(array);
            Console.WriteLine(string.Join("\n",array));
        }
    }
}
