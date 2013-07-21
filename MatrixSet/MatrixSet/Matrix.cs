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
        private Cell[,] cells;

        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    this.cells[x, y] = new Cell(x, y);
        }

        public Matrix(params string[] rows)
        {
            this.width = rows.Select(row => row.Length).Max();
            this.height = rows.Length;
            this.cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    this.cells[x, y] = new Cell(x, y);

            for (int y = 0; y < rows.Length; y++)
            {
                string row = rows[y];

                for (int x = 0; x < row.Length; x++)
                    if (row[x] == '1')
                        this.cells[x,y].Value = true;
            }
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }

        public bool Get(int x, int y)
        {
            return this.cells[x, y].Value;
        }

        public void Set(int x, int y, bool value)
        {
            this.cells[x, y].Value = value;
        }

        public IList<IList<Cell>> GetGreatestSets()
        {
            var result = new List<IList<Cell>>();

            for (int x = 0; x < this.width; x++)
                for (int y = 0; y < this.height; y++)
                    if (this.cells[x, y].Value)
                        result.Add(new List<Cell>() { this.cells[x, y] });

            return result;
        }
    }
}
