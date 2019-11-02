using P03_StudentSystem.Commands;
using P03_StudentSystem.IO;
using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private readonly IIoEngine ioEngine;
        private StudentsDatabase students;

        private Dictionary<string, ICommand> commands;

        public StudentSystem(IIoEngine ioEngine)
        {
            this.students = new StudentsDatabase();
            this.commands = new Dictionary<string, ICommand>
            {
                { "Create", new CreateCommand() },
                { "Show", new ShowCommand(ioEngine) },
                { "Delete", new DeleteCommand() }
            };
            this.ioEngine = ioEngine;
        }

        public void ParseCommands()
        {
            while (true)
            {
                string[] args = this.ioEngine.Read().Split();
                var commandName = args[0];
                if (this.commands.ContainsKey(commandName))
                {
                    var command = this.commands[commandName];
                    command.Execute(args, this.students);
                }
                else if (commandName == "Exit")
                {
                    return;
                }
            }
        }
    }
}
