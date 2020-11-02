using System;
using System.IO;

namespace BinaryWriter
{
    class BinaryWriter
    {
        static void Main(string[] args)
        {
            //byte[] bytes={ 48,49,50};
            using (FileStream binaryWriter = new FileStream("myFile.bin",FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                binaryWriter.Seek(1, SeekOrigin.Begin);

                var buffer = new byte[20];
                var read = binaryWriter.Read(buffer, 0, buffer.Length);
                Console.WriteLine(read);
                //binaryWriter.Write(bytes,0,bytes.Length);

            //for writing classes we use [Serialize] for write formatter.serialize(myStream,niki)
            //for reading classes we use formatter.deserialize(myStream)
            }
        }
    }
}
