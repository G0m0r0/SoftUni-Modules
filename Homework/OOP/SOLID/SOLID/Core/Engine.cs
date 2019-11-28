using SOLID.Appenders;
using SOLID.Enum;
using SOLID.Factories;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;

namespace SOLID.Core
{
    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;
        public Engine(CommandInterpreter commandIterpreter)
        {
            this.commandInterpreter = commandIterpreter;
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] inputInfo = input.Split(' ');

                if (input == "END")
                {
                    commandInterpreter.Read(inputInfo);
                    break;
                }

                commandInterpreter.Read(inputInfo);
                input = Console.ReadLine();
            }
        }
    }
}
