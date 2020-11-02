namespace SOLID.Loggers
{
    using System;
    using SOLID.Appenders;
    using SOLID.Enum;

    public class Logger:ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            for (int i = 0; i < Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, error, message);
            }
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime,string message)
        {
            Append(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime,string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime,string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }
    }
}
