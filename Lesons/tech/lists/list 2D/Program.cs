using System;
using System.Collections.Generic;

namespace list_2D
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList= new List<List<int>>();
            myList.Add(new List<int>() { 1, 2, 3 });
            myList.Add(new List<int>() { 1, 2, 3 });
            myList.Add(new List<int>() { 1, 2, 5 });
            myList.Add(new List<int>() { 1, 2, 4 });
            Console.WriteLine(myList.Count); //4

        }     
    }
}
