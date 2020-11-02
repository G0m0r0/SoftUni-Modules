using SOLID.Appenders;
using SOLID.Core;
using SOLID.Enum;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // ILayout simpleLayout = new SimpleLayout();
            // IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //  var file = new LogFile();
            //  var fileAppender = new FileAppender(simpleLayout, file);

            ///  ILogger logger = new Logger(consoleAppender,fileAppender);
            //  logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //  logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            // Console.WriteLine(file.Size);
            //  Console.WriteLine(((FileAppender)fileAppender).LogFile.Size);

            //var xmlLayout = new XmlLayout();
            //var consoleAppenderXml = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppenderXml);

            // var jasonLayout = new JasonLayout();
            // ILogFile logJason = new LogFile();
            // var consoleAppenderJason = new FileAppender(jasonLayout,logJason);
            // var loggerJason = new Logger(consoleAppenderJason);
            //
            // loggerJason.Info("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            // logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


            //  var simpleLayout = new XmlLayout();
            //  var lofFile = new LogFile();
            //  var fileAppender = new FileAppender(simpleLayout,lofFile);
            //  fileAppender.ReportLevel = ReportLevel.Error;
            //
            //  var logger = new Logger(fileAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
            // logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //  Console.WriteLine(((FileAppender)fileAppender).LogFile.Size);
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
