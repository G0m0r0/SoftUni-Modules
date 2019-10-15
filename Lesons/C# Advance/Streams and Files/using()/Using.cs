using System;
using System.IO;
using System.Text;

namespace using__
{
    class Using
    {
        static void Main(string[] args)
        {
            //close stream automatically
            //using IDisposable
            using (StreamWriter sw = new StreamWriter("myText.txt", false, Encoding.UTF8))
            {
                sw.WriteLine("ahha");
            }
            using (var reader = new StreamReader("lines.txt"))
            {
                for (int i = 0; i <= 10; i++)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    //output 7lines and 3 nulls
                }
            }
            using (var reader = new StreamReader("lines.txt"))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    //output 7lines
                }
            }
            //if we are using path file, we have to escape symbols like \ by making it double \\ ("D:\dsggs\sdgdgs")
            //or we can use (@"D:\dgds\")
        }
    }
}
