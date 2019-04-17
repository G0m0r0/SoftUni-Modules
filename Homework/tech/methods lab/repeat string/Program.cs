using System;
using System.Text;

namespace repeat_string
{
    class Program
    {
        static string RepeatString(string str,int numOfTimes)
        {
            string myNewStr = string.Empty;
            for (int i = 0; i < numOfTimes; i++)
            {
                myNewStr += str;
            }
            return myNewStr;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(str,num)); 
        }
    }
}
