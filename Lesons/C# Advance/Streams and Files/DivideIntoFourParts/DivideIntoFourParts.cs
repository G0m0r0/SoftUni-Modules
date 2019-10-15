using System;
using System.IO;

namespace DivideIntoFourParts
{
    class DivideIntoFourParts
    {
        static void Main(string[] args)
        {
            int n = 5;
            var totalSize=new FileInfo("lines.txt").Length;
            var sizePerFile =(int)Math.Ceiling(totalSize / 5.0); //example 102/5
            using (FileStream r=new FileStream("lines.txt",FileMode.Open))
            {
                for (int i = 1; i <= n; i++)
                {
                    var buffer = new byte[sizePerFile];
                    var readBytes=r.Read(buffer, 0, sizePerFile);
                    using(FileStream w=new FileStream($"file-{i}.txt",FileMode.OpenOrCreate))
                    {
                        w.Write(buffer, 0, readBytes);
                        string a = string.Empty;
                        File.WriteAllText                                                                         
                    }
                }
            }
        }
    }
}
