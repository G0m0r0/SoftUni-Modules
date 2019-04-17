using System;
using System.Linq;

namespace string_join___arr_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Sofia", "Plovdiv", "Varna", "Burgas" };
            //string allCities = string.Join(',', arr);
            // string.Join(", ",arr);
            //string.Join("??",arr);
            Console.WriteLine(string.Join(',',arr));
        }
    }
}
