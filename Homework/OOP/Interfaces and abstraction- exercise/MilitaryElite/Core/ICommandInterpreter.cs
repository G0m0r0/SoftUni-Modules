using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public interface ICommandInterpreter
    {
        public string Read(string[] args);
    }
}
