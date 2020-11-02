using SOLID.Appenders;
using SOLID.Enum;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            //TODO: fix this
            switch (type.ToLower())
            {
                case "consoleappender":
                    return new ConsoleAppender(layout) {ReportLevel=reportLevel };
                case "fileappender":
                    return new FileAppender(layout, new LogFile()) {ReportLevel=reportLevel };
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }

    }
}
