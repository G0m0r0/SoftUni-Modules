using System;

namespace custom_array
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var arrayInt = ArrayCreator.Create(100, 123);
            var arrayString = ArrayCreator.Create<string>(10, "Softuni"); //<string> is optional

        }
    }
}
