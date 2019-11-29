using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = (inputArgs[0]+"Command").ToLower();
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x=>x.Name.ToLower()==commandName);

            if(commandType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;

            if(instanceType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            string result = instanceType.Execute(commandArgs);

            return result;
        }
    }
}
