using System;
using System.Linq;

namespace array_manipulation
{
    class Program
    {
        static int ExtractNumbers(string command)
        {
            string[] array = command.Split(" ");
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(array[i], out num)) ;
                if (num != 0) return num;
            }
            return num;
        }

        static void ExchangeAray(int[] array, int numberOfRotations)
        {
            if (numberOfRotations < 0 || numberOfRotations >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= numberOfRotations; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        static int MaxOddEvenElement(int[] array, string commandODddEven)
        {
            int maxEvenOdd = int.MinValue;
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (commandODddEven == "even" && array[i] % 2 == 0)
                {
                    if (maxEvenOdd <= array[i])
                    {
                        index = i;
                        maxEvenOdd = array[i];
                    }
                }
                else if (commandODddEven == "odd" && array[i] % 2 != 0)
                {
                    if (maxEvenOdd <= array[i])
                    {
                        index = i;
                        maxEvenOdd = array[i];
                    }
                }
            }
            return index;
        }

        static int MinOddEvenElement(int[] array, string commandOddEven)
        {
            int min = int.MaxValue;
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (commandOddEven == "odd" && array[i] % 2 != 0)
                {
                    if (array[i] <= min)
                    {
                        index = i;
                        min = array[i];
                    }
                }
                else if (commandOddEven == "even" && array[i] % 2 == 0)
                {
                    if (array[i] <= min)
                    {
                        index = i;
                        min = array[i];
                    }
                }
            }
            return index;
        }

        static void FirstEvenOddElements(int[] array, string commandOddEven, int numberOfIntegers)
        {
            int counter = 0;
            string str = string.Empty;

            if (numberOfIntegers > array.Length || numberOfIntegers < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (counter == numberOfIntegers)
                    break;
                if (commandOddEven == "even" && array[i] % 2 == 0)
                {
                    counter++;
                    str += array[i] + ", ";
                }
                else if (commandOddEven == "odd" && array[i] % 2 != 0)
                {
                    counter++;
                    str += array[i] + ", ";
                }
            }
            if (counter != 0)
            {
                Console.WriteLine("[" + str.Trim().TrimEnd(',') + "]");
            }
            else if (counter == 0)
                Console.WriteLine("[]");

        }

        static void LastEvenOddElements(int[] array, string commandOddEven, int numberOfIntegers)
        {
            int counter = 0;
            string str = string.Empty;

            if (numberOfIntegers > array.Length || numberOfIntegers < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (counter == numberOfIntegers)
                    break;
                if (commandOddEven == "even" && array[i] % 2 == 0)
                {
                    counter++;
                    str += array[i] + ", ";
                }
                else if (commandOddEven == "odd" && array[i] % 2 != 0)
                {
                    counter++;
                    str += array[i] + ", ";
                }
            }

            if (counter != 0)
            {
                string[] reverseStr = str.Split(" ").ToArray();
                Array.Reverse(reverseStr);
                string reverse = "[" + (string.Join(" ", reverseStr)).Trim().TrimEnd(',') + ']';
                Console.WriteLine(string.Join("", reverse));
            }
            else if (counter == 0)
                Console.WriteLine("[]");
        }

        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                int numberOfTimes = ExtractNumbers(command);
                string[] commands = command.Split(" ").ToArray();

                int index = 0;

                switch (commands[0])
                {
                    case "exchange":
                        ExchangeAray(array, numberOfTimes);
                        break;
                    case "max":
                        index = MaxOddEvenElement(array, commands[1]);
                        if (index == -1)
                            Console.WriteLine("No matches");
                        else Console.WriteLine(index);
                        break;
                    case "min":
                        index = MinOddEvenElement(array, commands[1]);
                        if (index == -1)
                            Console.WriteLine("No matches");
                        else Console.WriteLine(index);
                        break;
                    case "first":
                        FirstEvenOddElements(array, commands[2], int.Parse(commands[1]));
                        break;
                    case "last":
                        LastEvenOddElements(array, commands[2], int.Parse(commands[1]));
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", array).Trim().TrimEnd(',') + "]");
        }
    }
}
