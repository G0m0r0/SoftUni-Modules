using System;
using System.Collections.Generic;

namespace HashSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("Pesho");
            set.Add("Pesho"); //Its not added again
            set.Add("Gosho");
            Console.WriteLine(string.Join(", ",set)); //Pesho, Gosho or Gosho, Pesho
            Console.WriteLine(set.Contains("Pesho")); //true
            Console.WriteLine(set.Contains("Something")); //false
            set.Remove("Pesho");
            Console.WriteLine(string.Join(", ",set)); //Gosho
            Console.WriteLine(set.Count); //1
        }
    }
}
