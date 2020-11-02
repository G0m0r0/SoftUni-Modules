using P03_StudentSystem.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Commands
{
    public class ShowCommand : ICommand
    {
        private readonly IIoEngine engine;

        public ShowCommand(IIoEngine engine)
        {
            this.engine = engine;
        }
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
            var student = database.Find(name);
            if (student != null)
                //Console.WriteLine(student.ToString());
                this.engine.Write(student.ToString());
        }
    }
}
