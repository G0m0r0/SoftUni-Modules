using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace char_string_and_operation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaa".Length == "baa".Length); //compare the length aways output true or false 
            Console.WriteLine("aaa".Length == int.Parse("3")); //compare the lenght with 3
            char first = char.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine(first != second);
            Console.WriteLine(100 < 10); //output false
            Console.Read();
            //cw tab tab Console.Readline();
            //hold Alt then mark for multiline comment
            /*
            //if tab tab shows construction below 
            if (true)
            {

            }
            */
        }   
    }       
}
