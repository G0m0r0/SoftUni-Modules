using SOLID.Enum;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime,LogLevel logLevel,string message)
        {
            Console.WriteLine(this.Layout.Format,dateTime,logLevel,message);
        }
    }
}
