using System;
using System.IO;
using System.Text;

namespace Streams_and_Files
{
    class StreamsAndFiles
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;
            StreamWriter write = new StreamWriter("myTextFile.txt"); //6 byte
            //StreamWriter write = new StreamWriter("myTextFile.txt",false, Encoding.Unicode); //14byte
            //StreamWriter write = new StreamWriter("myTextFile.txt",false, Encoding.UTF32); //28byte
            write.Write("Hello!");
            write.Close();

            //not very common
            //FileStream fileSt = new FileStream("", FileMode.Open, FileAccess.ReadWrite);
            //StreamWriter write = new StringWriter("myTextFile.txt", false, Encoding.GetEncoding("windows-1251"));
        }
    }
}
