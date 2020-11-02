using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        static void Main()
        {
            int[] dimestions = ReadInput(Console.ReadLine());
            MatrixField matrix = CreateMatrix(dimestions);

            InitializeMatrix(matrix);
            
            long sum = 0;
            string command = string.Empty;
            while ((command=Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoS = ReadInput(command);
                Ivo ivo = CreateIvo(ivoS);

                int[] evilArgs = ReadInput(Console.ReadLine());
                Evil evil = CreateEvil(evilArgs);

                while (evil.X >= 0 && evil.Y >= 0)
                {
                    if (ValidCell(evil.X, evil.Y, matrix))
                    {
                        matrix[evil.X, evil.Y] = 0;
                    }
                    evil.X--;
                    evil.Y--;
                }
         
                while (ivo.X >= 0 && ivo.Y < matrix.GetLengthY())
                {
                    if (ValidCell(ivo.X,ivo.Y,matrix))
                    {
                        sum += matrix[ivo.X, ivo.Y];
                    }

                    ivo.X--;
                    ivo.Y++;
                }

            }

            Console.WriteLine(sum);

        }

        private static MatrixField CreateMatrix(int[] dimestions)
        {
            int x = dimestions[0];
            int y = dimestions[1];
            MatrixField matrix = new MatrixField(x, y);

            return matrix;
        }

        private static int[] ReadInput(string input)
        {
            return input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void InitializeMatrix(MatrixField matrix)
        {
            int value = 0;
            for (int i = 0; i < matrix.GetLengthX(); i++)
            {
                for (int j = 0; j < matrix.GetLengthY(); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static Ivo CreateIvo(int[] ivoS)
        {
            int xIvo = ivoS[0];
            int yIvo = ivoS[1];
            Ivo ivo = new Ivo(xIvo, yIvo);

            return ivo;
        }

        private static Evil CreateEvil(int[] args)
        {            
            int xEvil = args[0];
            int yEvil = args[1];
            Evil evil = new Evil(xEvil, yEvil);

            return evil;
        }

        private static bool ValidCell(int x, int y, MatrixField matrix)
        {
            if (x >= 0 && x < matrix.GetLengthX() &&
                y >= 0 && y < matrix.GetLengthY())
            {
                return true;
            }

            return false;
        }
    }
}
