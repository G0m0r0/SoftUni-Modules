using SOLID.Enum;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID.Appenders
{
    class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile):base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }
       // public ReportLevel ReportLevel { get; set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.LogFile.Write(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.counter++;
            }
        }

        public override string ToString()
        {
            return base.ToString()+ $" File size: {this.LogFile.Size}";
        }
    }
}
