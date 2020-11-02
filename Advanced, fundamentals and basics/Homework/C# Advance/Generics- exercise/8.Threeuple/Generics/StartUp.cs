using System;
using System.Linq;

namespace Generics
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine()
                .Split();
            string fullName = tokens[0] + " " + tokens[1];
            string adress = tokens[2];
            string town = string.Join(" ", tokens.Skip(3));

            tokens = Console.ReadLine()
                .Split();
            string name = tokens[0];
            int litersOfBeer = int.Parse(tokens[1]);
            bool drunkOrNot =tokens[2]=="drunk"?true:false;

            tokens = Console.ReadLine()
                .Split();
            string nameOfPersonBank = tokens[0];
            double acountBalance = double.Parse(tokens[1]);
            string bankname = tokens[2];

            var threeuple1 = new Threeuple<string, string, string>(fullName, adress, town);
            var threeuple2 = new Threeuple<string, int, bool>(name, litersOfBeer, drunkOrNot);
            var threeuple3 = new Threeuple<string, double, string>(nameOfPersonBank, acountBalance, bankname);

            Console.WriteLine(threeuple1.ToString());
            Console.WriteLine(threeuple2.ToString());
            Console.WriteLine(threeuple3.ToString());
        }
    }
}
