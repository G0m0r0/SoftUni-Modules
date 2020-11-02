using System;
using System.Text.RegularExpressions;

namespace test_2_password
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex password = new Regex(@"[A-Z][a-z]?");
        }
    }
}
