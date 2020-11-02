using SOLID.Enum;
using SOLID.Layouts;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        void Append(string dateTime,ReportLevel reportLevel, string message);

        public ReportLevel ReportLevel { get; set; }
    }
}
