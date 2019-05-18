using System;
using System.Collections;
using System.Collections.Generic;

namespace extension_methods
{
    class ExtensionMethods
    {
        static void Main(string[] args)
        {
            //same for stack and queue
            //linq
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
           
            int count = stack.Count;
            //item
            bool exist = stack.Contains(2);
            int[] array = stack.ToArray();
            //delete all elements
            stack.Clear();
            //loose unneed memory not very fast- more ram
            stack.TrimExcess();
        }
    }
}
