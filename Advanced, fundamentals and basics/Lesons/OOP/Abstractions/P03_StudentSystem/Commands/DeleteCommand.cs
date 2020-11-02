using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Commands
{
    class DeleteCommand : ICommand
    {
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
           // database.Delete()
        }
    }
}
