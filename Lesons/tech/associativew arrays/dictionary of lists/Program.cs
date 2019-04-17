using System;
using System.Collections.Generic;

namespace dictionary_of_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SortedDictionary<string, List<char>>();
            list.Add("niki", new List<char> { 'n', 'b', 'j', 'g' });
            
        }
    }
}
