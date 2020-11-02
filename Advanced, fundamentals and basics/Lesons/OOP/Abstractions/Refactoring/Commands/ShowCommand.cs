using P03_StudentSystem.IO;
using System;

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
            {
                this.engine.Write(student.ToString());
            }
        }
    }
}
