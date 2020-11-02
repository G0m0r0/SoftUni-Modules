using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = Console.ReadLine();
            while (choice != "END")
            {
                string dataType = string.Empty;
                try
                {
                    int number = int.Parse(choice);
                    dataType = "integer";
                }
                catch (FormatException)
                {
                    try
                    {
                        double number = double.Parse(choice);
                        dataType = "floating point";
                    }
                    catch (FormatException)
                    {
                        try
                        {
                            char number = char.Parse(choice);
                            dataType = "character";
                        }
                        catch (FormatException)
                        {
                            try
                            {
                                bool number = bool.Parse(choice);
                                dataType = "boolean";
                            }
                            catch (FormatException)
                            {
                                dataType = "string";
                            }
                        }
                    }
                }
                Console.WriteLine($"{choice} is {dataType} type");
                choice = Console.ReadLine();
            }
        }
    }
}