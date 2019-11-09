using System.IO;

namespace Encapsulation
{
    public class FileMinimalSalaryProvider : IMinimalSalaryProvider
    {
        public int GetMinimalSalary()
        {
            var fileContent =File.ReadAllLines("settings.txt");
            return int.Parse(fileContent[0]);
        }
    }

}
