using System;
using System.IO;

namespace _4._1_Merge_Files
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            string pathOne = @"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\04. Merge Files\FileOne.txt";
            string pathTwo = @"D:\Programming\Softuni\Homework\C# Advance\Streams and files- lab\Resources\04. Merge Files\FileTwo.txt";
            int counter = 0;
            using (StreamReader readerOne = new StreamReader(pathOne))
            {
                using (StreamReader readerTwo = new StreamReader(pathTwo))
                {
                    using (StreamWriter writer=new StreamWriter("OutPut.txt"))
                    {
                        while (!readerOne.EndOfStream||!readerTwo.EndOfStream)
                        {
                            if (counter % 2 == 0)
                            {
                                string line = readerOne.ReadLine();
                                writer.WriteLine(line);
                            }
                            else
                            {
                                string line = readerTwo.ReadLine();
                                writer.WriteLine(line);
                            }
                            counter++; 
                        }  
                    }
                }
            }
        }

    }
}

