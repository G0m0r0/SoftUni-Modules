using System;
using System.IO;

namespace _4._Merge_Files
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            const int chunkSize = 2 * 1024; // 2KB
            var inputFiles = new[] { "FileOne.txt", "FileTwo.txt"};
            using (var output = File.Create("output.txt"))
            {
                foreach (var file in inputFiles)
                {
                    using (var input = File.OpenRead(file))
                    {
                        var buffer = new byte[chunkSize];
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}
