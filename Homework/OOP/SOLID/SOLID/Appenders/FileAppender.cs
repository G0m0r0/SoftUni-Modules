using SOLID.Enum;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID.Appenders
{
    class FileAppender:IAppender
    {
        public FileAppender(ILayout layout,LogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; }

        public void Append(string dateTime, LogLevel logLevel, string message)
        {
            this.LogFile.Write(string.Format(this.Layout.Format,dateTime,logLevel,message));
        }
    }
}
