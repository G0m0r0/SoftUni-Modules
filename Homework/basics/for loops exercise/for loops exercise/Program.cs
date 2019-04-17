using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_loops_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
           for(int i=7;i<=997;i++)
            {
                if (i % 10 == 7) Console.WriteLine(i);
            }     
        }
    }
}
