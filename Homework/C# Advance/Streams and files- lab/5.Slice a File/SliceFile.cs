using System;
using System.IO;

namespace _5.Slice_a_File
{
    class SliceFile
    {
        static void Main(string[] args)
        {
            int numberOfFiles = 4;
            var totalSize = new FileInfo(@"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\05. Slice File\sliceMe.txt").Length;
            var sizePerFile = (int)Math.Ceiling(totalSize / 4.0);
            using (FileStream r=new FileStream(@"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\05. Slice File\sliceMe.txt",FileMode.Open))
            {
                for (int i = 1; i <= numberOfFiles; i++)
                {
                    var buffer = new byte[sizePerFile];
                    var readBytes = r.Read(buffer, 0, sizePerFile);
                    using (FileStream w=new FileStream($"file-{i}.txt",FileMode.OpenOrCreate))
                    {
                        w.Write(buffer, 0, sizePerFile);
                    }
                }
            }
        }
    }
}
