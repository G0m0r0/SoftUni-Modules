using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs[0];
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            ICommand command= null;

            switch (commandName)
            {
                case "Hello":
                    command = new HelloCommand();
                    break;
                case "Exit":
                    command = new ExitCommand();
                    break;
                default:
                    throw new ArgumentException("Invalid command type");
            }

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
