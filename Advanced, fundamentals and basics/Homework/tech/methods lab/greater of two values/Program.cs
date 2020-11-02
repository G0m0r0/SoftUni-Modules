using System;

namespace greater_of_two_values
{
    class Program
    {
       static int GetmaxInt(int a,int b)
        {
            return a > b ? a : b;
        }
        static string GetmaxStr(string a,string b)
        {
            int result = a.CompareTo(b);
            if (result == 1) return a;
            return b;

        }
        static char GetmaxChar(char a,char b)
        {
            return a > b ? a : b;
        }
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string firstElement = Console.ReadLine();
            string secondElement = Console.ReadLine();

            if (dataType == "int")
                Console.WriteLine(GetmaxInt(int.Parse(firstElement), int.Parse(secondElement)));
            else if (dataType == "string")
                Console.WriteLine(GetmaxStr(firstElement, secondElement));
            else if (dataType == "char")
                Console.WriteLine(GetmaxChar(char.Parse(firstElement), char.Parse(secondElement)));
        }
    }
}
