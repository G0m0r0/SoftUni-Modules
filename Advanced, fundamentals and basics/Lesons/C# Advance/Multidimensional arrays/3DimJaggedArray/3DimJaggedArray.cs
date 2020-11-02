using System;

namespace _3DimJaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][][] DimJagged = new int[10][][];
            DimJagged[0] = new int[10][];
            DimJagged[1] = new int[5][];
            DimJagged[2] = new int[3][];

            DimJagged[1][7] = new int[20];
            DimJagged[1][7][4] = 5;

        }
    }
}
