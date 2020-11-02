using System;
using System.IO;

namespace ConsoleApp1
{
    class Directories
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("TestFolder");
            Directory.Delete("TestFolder", true); //true delete all content
            Directory.GetFiles("path");
            string[] filesInDir = Directory.GetFiles("path"); //returns all the names of the files with their paths
            string[] subDirs = Directory.GetDirectories("path"); //returns the names of subdirectories

            //calculate folders size
            string[] files = Directory.GetFiles("path");
            double sum = 0;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            sum = sum / 1024 / 1024;
        }
    }
}
