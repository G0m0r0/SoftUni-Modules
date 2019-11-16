using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;

            Citizen citizen = new Citizen();
            while ((input=Console.ReadLine())!="End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(tokens.Length==2)
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    ICitizen robot = new Robot(model, id);
                    citizen.AddCitizen(robot);

                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    ICitizen person = new Person(name, age, id);
                    citizen.AddCitizen(person);
                }
            }

            string idToDetaind = Console.ReadLine();
            citizen.PrintDetainedIds(idToDetaind);
        }
    }
}
