using System;

namespace template_collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
        }
    }
}
