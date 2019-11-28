using SOLID.Appenders;
using SOLID.Enum;
using SOLID.Factories;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core
{
    public class CommandInterpreter
    {
        //this class is not implimented correctly
        private readonly List<IAppender> appenders;
        private ILogger logger;
        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
        }
       // ILogger logger = new Logger(appenders.ToArray());
        public void Read(string[] args)
        {
            string command = args[0];
            if (command=="Create")
            {
                CreateAppender(args);
            } 
            else if(command=="Append")
            {
                logger = new Logger(appenders.ToArray());
                AppendMessage(args);
            }
            else if(command=="END")
            {
                PrintInfo();
            }
        }
        private void PrintInfo()
        {
            Console.WriteLine("Logger info");


            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
        private void CreateAppender(string[] inputInfo)
        {
            string appenderType = inputInfo[1];
            string layoutType = inputInfo[2];
            ReportLevel reportLevel = ReportLevel.Info;
            if (inputInfo.Length > 2)
            {
                //reportLevel = Enum.Parse<ReportLevel>(inputInfo[3], true);
            }
            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }

        private void AppendMessage(string[] inputInfo)
        {
            string loggerMerhodtype = inputInfo[0];
            string date = inputInfo[1];
            string message = inputInfo[2];

            if (loggerMerhodtype == "INFO")
            {
                logger.Info(date, message);
            }
            else if (loggerMerhodtype == "WARNING")
            {
                logger.Warning(date, message);
            }
            else if (loggerMerhodtype == "ERROR")
            {
                logger.Error(date, message);
            }
            else if (loggerMerhodtype == "CRITICAL")
            {
                logger.Critical(date, message);
            }
            else if (loggerMerhodtype == "FATAL")
            {
                logger.Fatal(date, message);
            }
        }
    }
}
