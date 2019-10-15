using System;
using System.IO;

namespace Get_size_of_directories
{
    class GetSizeOfDirectories
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var totalLengh = 0L;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                totalLengh+= fileInfo.Length;
            }

            Console.WriteLine(totalLengh);
        }
    }
}
