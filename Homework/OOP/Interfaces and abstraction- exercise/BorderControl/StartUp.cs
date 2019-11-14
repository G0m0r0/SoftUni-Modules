using System;

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
                    Robot robot = new Robot(model, id);
                    citizen.AddRobot(robot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Person person = new Person(name, age, id);
                    citizen.AddPerson(person);
                }
            }

            string idToDetaind = Console.ReadLine();
            citizen.PrintDetainCitizen(idToDetaind);
        }
    }
}
