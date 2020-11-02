using System;
using System.IO;
using System.Linq;
using System.Text;
using SOLID.Appenders;

namespace SOLID.Loggers
{
    class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message+Environment.NewLine);
        }

        public int Size => File
            .ReadAllText(LogFilePath)
            .Replace(" ", "")
            .Where(c => char.IsLetter(c))
            .Sum(x => x);

       //private void CreateFileIfDoesntExist()
       //{
       //    bool doestExit = File.Exists(LogFilePath);
       //
       //    if(!doestExit)
       //    {
       //        File.Create(LogFilePath);
       //    }
       //}
    }
}
