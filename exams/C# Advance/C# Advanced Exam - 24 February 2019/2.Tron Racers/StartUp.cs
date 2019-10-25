using System;

namespace _2.Tron_Racers
{
    class StartUp
    {
        static char[,] field;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            field = new char[size, size];

            int xFPosition = 0;
            int yFPosition = 0;
            int xSPosition = 0;
            int ySPosition = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = rowInput[j];
                    if (field[i, j] == 'f')
                    {
                        xFPosition = i;
                        yFPosition = j;
                    }
                    else if (field[i, j] == 's')
                    {
                        xSPosition = i;
                        ySPosition = j;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string playerFCommand = tokens[0];
                string playerSCommand = tokens[1];

                switch (playerFCommand)
                {
                    case "up":
                        xFPosition--;
                        break;
                    case "down":
                        xFPosition++;
                        break;
                    case "right":
                        yFPosition++;
                        break;
                    case "left":
                        yFPosition--;
                        break;
                }
                switch (playerSCommand)
                {
                    case "up":
                        xSPosition--;
                        break;
                    case "down":
                        xSPosition++;
                        break;
                    case "right":
                        ySPosition++;
                        break;
                    case "left":
                        ySPosition--;
                        break;
                }

                OutSideTheField(ref xFPosition, ref yFPosition, ref xSPosition, ref ySPosition);

                if(field[xFPosition,yFPosition]=='s')
                {
                    field[xFPosition, yFPosition] = 'x';
                    break;
                }
                field[xFPosition, yFPosition] = 'f';

                if (field[xSPosition,ySPosition]=='f')
                {
                    field[xSPosition, ySPosition] = 'x';
                    break;
                }
                field[xSPosition, ySPosition] = 's';
            }

            PrintField();
        }

        private static void PrintField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void OutSideTheField(ref int xF, ref int yF, ref int xS, ref int yS)
        {
            if(xF<0)
            {
                xF = field.GetLength(1) - 1;
            }
            else if(xF>field.GetLength(1)-1)
            {
                xF = 0;
            }
            else if(yF<0)
            {
                yF = field.GetLength(0) - 1;
            }
            else if(yF>field.GetLength(0)-1)
            {
                yF = 0;
            }

            if (xS < 0)
            {
                xS = field.GetLength(1) - 1;
            }
            else if (xS > field.GetLength(1) - 1)
            {
                xS = 0;
            }
            else if (yS < 0)
            {
                yS = field.GetLength(0) - 1;
            }
            else if (yS > field.GetLength(0) - 1)
            {
                yS = 0;
            }
        }
    }
}
