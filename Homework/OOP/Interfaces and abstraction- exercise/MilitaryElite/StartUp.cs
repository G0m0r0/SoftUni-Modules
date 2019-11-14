using MilitaryElite.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            while((command=Console.ReadLine())!="End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

               if(command.StartsWith("Private"))
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                }
               else if(command.StartsWith("LieutenantGeneral"))
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    string[] privatesId = tokens.Skip(5).ToArray();
                }
            }
        }
    }
}
