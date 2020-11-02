using System;
using System.Collections.Generic;
using System.Linq;

namespace InteratorsAndComperators
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> elements = command
                .Split()
                .Skip(1)
                .ToList();

            ListyIterator<string> listyInterator = new ListyIterator<string>(elements);

            while ((command = Console.ReadLine()) != "END")
            {
                bool trueOrFalse = true;
                if (command == "HasNext")
                {
                    trueOrFalse = listyInterator.HasNext();
                    Console.WriteLine(trueOrFalse);
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyInterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Move")
                {
                    trueOrFalse = listyInterator.Move();
                    Console.WriteLine(trueOrFalse);
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ",listyInterator));
                    //or
                   // foreach (var item in listyInterator)
                   // {
                   //     Console.Write(item + " ");
                   // }
                   // Console.WriteLine();
                }

            }
        }
    }
}
