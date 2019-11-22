namespace SOLID.Loggers
{
    using SOLID.Appenders;
    using SOLID.Enum;

    public class Logger:ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Error(string dateTime,string message)
        {
            for (int i = 0; i < Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, LogLevel.Error, message);
            }           
        }

        public void Info(string dateTime,string message)
        {
            for (int i = 0; i < Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, LogLevel.Info, message);
            }
        }

        public void Warning(string dateTime,string message)
        {

        }
    }
}
