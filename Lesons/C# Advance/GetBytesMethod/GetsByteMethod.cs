using System;
using System.Text;

namespace GetBytesMethod
{
    class GetsByteMethod
    {
        static void Main(string[] args)
        {
            var a = Encoding.UTF8.GetBytes("абв");
            var b = Encoding.UTF8.GetBytes("012");
        }
    }
}
