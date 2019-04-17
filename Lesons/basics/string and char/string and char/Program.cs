using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_and_char
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine('a'+'b'); //output ascii sum 195
            Console.WriteLine('a' + "b"); //output ab
            Console.WriteLine('a' +'a'+ "b");//output 194b 
            //'a'+'a' convert to ascii because we have two ascii numbers
            //'a'+"b" there is noting to sum
            Console.WriteLine('a'); //output a    
            Console.WriteLine((int)'a'); //output 97
            Console.WriteLine((char)'a'); //output a
        }
    }
}
