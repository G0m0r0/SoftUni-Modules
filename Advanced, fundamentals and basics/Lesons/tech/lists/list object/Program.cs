using System;
using System.Collections.Generic;

namespace list_object
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<object> list = new List<object>();
            list.Add(1);
            list.Add("2");
            list.Add(3.0);
            list.Add('4');

            //there is no obeject b=a+3;
            object[] array=new object[2];
            array[0] = 1;
            array[1] = "string";
            array[2] = 3.14;
        }
    }
}
