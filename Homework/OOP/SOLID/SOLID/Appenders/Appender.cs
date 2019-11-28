using SOLID.Enum;
using SOLID.Layouts;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        protected int counter { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.counter}";
        }

    }
}
