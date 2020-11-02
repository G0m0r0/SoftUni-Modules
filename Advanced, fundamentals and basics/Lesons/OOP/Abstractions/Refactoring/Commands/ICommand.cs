using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Commands
{
    public interface ICommand
    {
        void Execute(string[] args, StudentsDatabase database);
    }
}
