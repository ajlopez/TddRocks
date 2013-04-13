namespace Lawnmover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Pattern
    {
        private int width;
        private int height;
        private int[,] cells;

        public Pattern(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.cells = new int[width, height];
        }

        public void SetRow(int nrow, string values)
        {
            string[] numbers = values.Split(' ');
            IList<int> ivalues = new List<int>();

            foreach (var number in numbers)
                ivalues.Add(int.Parse(number));

            this.SetRow(nrow, ivalues);
        }

        public void SetRow(int nrow, IList<int> values)
        {
            for (int k = 0; k < width; k++)
                this.cells[nrow, k] = values[k];
        }

        public int GetCell(int nrow, int ncol)
        {
            return this.cells[nrow, ncol];
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }
    }
}
