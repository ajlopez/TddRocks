namespace MatrixSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        private int width;
        private int height;
        private bool[,] values;

        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.values = new bool[width, height];
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }

        public bool Get(int x, int y)
        {
            return this.values[x, y];
        }
    }
}
