using System;

namespace data_types_more_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = Console.ReadLine();
            int valueInt = 0;
            float valueFloat = 0;
            char valueChar = ' ';
            bool valueBoolean = true;
            while (choice!="END")
            {
                if(int.TryParse(choice,out valueInt))
                    Console.WriteLine($"{choice} is integer type");
                else if(float.TryParse(choice, out valueFloat))
                    Console.WriteLine($"{choice} is floating point type");
                else if(char.TryParse(choice,out valueChar))
                    Console.WriteLine($"{choice} is character type");
                else if(bool.TryParse(choice,out valueBoolean))
                    Console.WriteLine($"{choice} is boolean type");
                else Console.WriteLine($"{choice} is string type");
                choice = Console.ReadLine();
            }
        }
    }
}
