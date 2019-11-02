using P03_StudentSystem.Commands;
using P03_StudentSystem.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private StudentsDatabase students;
        private readonly IIoEngine ioEngine;
        private Dictionary<string, ICommand> commands;
        public StudentSystem(IIoEngine ioEngine)
        {
            this.students = new StudentsDatabase();
            this.commands = new Dictionary<string, ICommand>
            {
                { "Create", new CreateCommand() },
                { "Show", new ShowCommand(ioEngine) },
                {"Delete",new DeleteCommand() }
            };
            this.ioEngine = ioEngine;
        }
        public void ParseCommands()
        {
            while (true)
            {
                string[] args = this.ioEngine.Read().Split();
                var command = args[0];

                if(this.commands.ContainsKey(command))
                {
                    var actionCommand = this.commands[command];
                    actionCommand.Execute(args, this.students);
                }
                else if(command=="Exit")
                {
                    return;
                }
                      
            }            
        }
    }
}
