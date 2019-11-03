using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class MatrixField
    {
        public int[,] Matrix { get; set; }
        public int Index { get; set; }

        public MatrixField(int x,int y)
        {
            this.Matrix = new int[x, y];
        }

        public int this[int idx1,int idx2]
        {
            get { return Matrix[idx1,idx2]; }
            set { Matrix[idx1,idx2] = value; }
        }

        public int GetLengthX()
        {
            return this.Matrix.GetLength(0);
        }
        public int GetLengthY()
        {
            return this.Matrix.GetLength(1);
        }
    }
}
