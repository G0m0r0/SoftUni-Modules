using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] sites = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                SmartPhone smarPhone = new SmartPhone(sites.ToList(), numbers.ToList());
                smarPhone.CallAll();
                smarPhone.BrowseAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
