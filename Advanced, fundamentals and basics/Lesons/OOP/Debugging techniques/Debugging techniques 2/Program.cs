using System;
using System.IO;
using System.Threading.Tasks;

namespace Debugging_techniques_2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                int value = i; 
            }

            Task.Run(() => ReadFileAsync("../../../TestFile.txt"));
        }

        public static async Task ReadFileAsync(string path)
        {
            string content = await File.ReadAllTextAsync(path);
            Console.WriteLine(content);
        }
            
    }
}
