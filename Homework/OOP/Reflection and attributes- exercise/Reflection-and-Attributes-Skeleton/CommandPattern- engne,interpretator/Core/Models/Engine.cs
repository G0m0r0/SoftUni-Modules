using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class Engine:IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInter)
        {
            this.commandInterpreter = commandInter;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exit")
            {
                string result = commandInterpreter.Read(input);

                Console.WriteLine(result);
            }
        }
    }
}
