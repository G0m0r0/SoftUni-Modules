using SOLID.Enum;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
                this.counter++;
            }
        }
    }
}
