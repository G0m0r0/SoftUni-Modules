using System;

namespace balanced_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            bool flag=true;
            string lastParentheses = ")";
         //   bool parenthases = false;
            for (int i = 0; i < numOfLines; i++)
            {      
                string str = Console.ReadLine();
                if (str == "(")
                {
                  //  parenthases = true;
                    if (lastParentheses == "(")
                        flag = false;
                    lastParentheses = "(";
                }
                else if (str == ")")
                {
                  //  parenthases = true;
                    if (lastParentheses == ")")
                        flag = false;
                    lastParentheses = ")";
                }
            }
            if (flag == true&&lastParentheses==")") Console.WriteLine("BALANCED"); 
            else Console.WriteLine("UNBALANCED");
        }
    }
}
