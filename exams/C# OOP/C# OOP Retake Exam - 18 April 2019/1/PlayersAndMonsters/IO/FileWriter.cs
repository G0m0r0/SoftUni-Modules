using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayersAndMonsters.IO
{
    public class FileWriter : IWriter
    {
        private FileStream fs;
        private StreamWriter sw;

        public FileWriter()
        {
            this.fs = new FileStream("./output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            this.sw = new StreamWriter(fs);

            sw.AutoFlush = true;

            Console.SetOut(sw);
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message)
        {
            Console.Write(message);
        }
    }
}
