using MilitaryElite.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }        
    }
}
