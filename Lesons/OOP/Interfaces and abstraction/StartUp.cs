using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Interfaces_and_abstraction
{
    public interface ILineWriter
    {
        void WriteLine(string line);
    }
    public interface ISameLineWriter
    {
        void Write(string text);
    }
    public interface IWriter : ILineWriter, ISameLineWriter
    {
        void WriteLines(IEnumerable[] lines);

        string Name { get; }
    }
    public class ConsoleWriter : IWriter
    {
        public string Name => "ConsoleWriter";

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteLines(string[] lines)
        {
            foreach (var line in lines)
            {
                this.WriteLine(line);
            }
        }

        public void WriteLines(IEnumerable[] lines)
        {
            throw new NotImplementedException();
        }
    }

    public class FileWriter : IWriter,IDisposable
    {
        private StreamWriter streamWriter;
        public FileWriter(string fileName)
        {
            this.streamWriter = new StreamWriter(fileName);           
        }

        public string Name => "FileWriter";

        public void Dispose()
        {
            this.streamWriter.Dispose();
        }

        public void Write(string text)
        {
            this.streamWriter.Write(text);
            this.streamWriter.Flush();
        }

        public void WriteLine(string line)
        {
            this.streamWriter.WriteLine(line);
            this.streamWriter.Flush();
        }

        public void WriteLines(string[] lines)
        {
            foreach (var line in lines)
            {
                this.streamWriter.WriteLine(line);                
            }
            this.streamWriter.Flush();
        }

        public void WriteLines(IEnumerable[] lines)
        {
            throw new NotImplementedException();
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            ///ILineWriter writer = new ConsoleWriter();
            //PrintHello(new FileWriter("output.txt"));
            using (var writer = new FileWriter("output.txt")) 
            {
                PrintHello(writer);
            }
        }
        static void PrintHello(ILineWriter write)
        {
            write.WriteLine("Hello");
        }
    }
}
