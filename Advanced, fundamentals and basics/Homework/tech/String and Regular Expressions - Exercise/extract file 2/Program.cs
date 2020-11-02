using System;

namespace extract_file_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);
            string[] fileAndIndex = file.Split('.');
            Console.WriteLine($"File name: {fileAndIndex[0]}");
            Console.WriteLine($"File extension: {fileAndIndex[1]}");
        }
    }
}
