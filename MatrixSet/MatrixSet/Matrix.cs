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

        public Matrix(params string[] rows)
        {
            this.width = rows.Select(row => row.Length).Max();
            this.height = rows.Length;
            this.values = new bool[width, height];

            for (int y = 0; y < rows.Length; y++)
            {
                string row = rows[y];

                for (int x = 0; x < row.Length; x++)
                    if (row[x] == '1')
                        this.Set(x, y, true);
            }
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }

        public bool Get(int x, int y)
        {
            return this.values[x, y];
        }

        public void Set(int x, int y, bool value)
        {
            this.values[x, y] = value;
        }
    }
}
