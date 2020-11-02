using System;
using System.Collections.Generic;

namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //using collection.generic
            List<string> name = new List<string>();
            name.Add("Peter");
            name.Add("Maria");
            name.Add("Georgi");
            name.Add("Viktor");
            name.Add("Pesho");

            //or

            var list = new List<string>
            {
                "string ",
                "second string",
                "more string"
            };

            Console.WriteLine(string.Join(" ",list));

            foreach (var item in name)
            {
                Console.WriteLine(item);
            }

            //Optional
            Console.WriteLine(string.Join(", ",name));
        }          
    
    }
}
