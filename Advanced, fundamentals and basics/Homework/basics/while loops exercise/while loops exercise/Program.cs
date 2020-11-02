using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while_loops_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a= uint.Parse(Console.ReadLine());
            uint b = uint.Parse(Console.ReadLine());
            uint result = b;
            if(b==0)
            {
                result = a;
            }
            else
            {
                while(b!=0)
                {
                    result = b;
                    b = a % b;
                    a = result;
                }
            }
            Console.WriteLine(result);
        }
    }
}
