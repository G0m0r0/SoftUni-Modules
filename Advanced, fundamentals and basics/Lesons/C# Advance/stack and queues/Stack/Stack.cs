using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    class Stack
    {
        static void Main(string[] args)
        {
            //empty constructor ctor
            Stack<int> stack1 = new Stack<int>();

            //custom elements in stack
            Stack<int> stack2 = new Stack<int>(12);

            //icollection value
            string[] values = { "Advance", "OOP", "OPP Advance" };
            Stack<string> stack3 = new Stack<string>(values);

        }
    }
}
