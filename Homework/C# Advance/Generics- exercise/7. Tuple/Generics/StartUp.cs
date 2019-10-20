using System;
using System.Collections.Generic;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = tokens[0] + " " + tokens[1];
            string addres = tokens[2];
            Tuple<string, string> tuple1 = new Tuple<string, string>(fullName, addres);

            tokens = Console.ReadLine()
                    .Split();
            string name = tokens[0];
            int litersOfBeer = int.Parse(tokens[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name, litersOfBeer);

            tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int myInt = int.Parse(tokens[0]);
            double myDouble = double.Parse(tokens[1]);
            Tuple<int, double> tuple3 = new Tuple<int, double>(myInt,myDouble);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}

