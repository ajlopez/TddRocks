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
                {
                    var set = this.GetGreatestSetFrom(x, y);

                    if (set == null)
                        continue;

                    if (result.Count == 0) 
                    {
                        result.Add(set);
                        continue;
                    }

                    if (set.Count > result[0].Count) 
                    {
                        result = new List<IList<Cell>>() { set };
                        continue;
                    }

                    if (set.Count == result[0].Count)
                        result.Add(set);
                }

            return result;
        }

        private IList<Cell> GetGreatestSetFrom(int x, int y)
        {
            var cell = this.cells[x, y];

            if (!cell.Value)
                return null;

            var set = new List<Cell>() { cell };
            IList<Cell> greatest = set;

            for (int x2 = x + 1; x2 < this.width; x2++)
            {
                var result = ExpandSet(set, x, y, x2, y);

                if (result != null && result.Count > greatest.Count)
                    greatest = result;
            }

            for (int y2 = y + 1; y2 < this.height; y2++)
            {
                var result = ExpandSet(set, x, y, x, y2);

                if (result != null && result.Count > greatest.Count)
                    greatest = result;
            }

            return greatest;
        }

        private IList<Cell> ExpandSet(IList<Cell> set, int left, int top, int x, int y)
        {
            var cell = this.cells[x, y];

            if (!cell.Value)
                return null;

            var newset = new List<Cell>(set);
            newset.Add(cell);

            if (top < y)
                foreach (var topcell in set.Where(c => c.Y == top && c.X < x))
                {
                    var newcell = this.cells[topcell.X, y];

                    if (!newcell.Value)
                        return null;

                    newset.Add(newcell);
                }

            IList<Cell> greatest = newset;

            if (top == y)
                for (int newx = x + 1; newx < this.width; newx++)
                {
                    var newset2 = this.ExpandSet(newset, left, top, newx, y);

                    if (newset2 != null && newset2.Count > greatest.Count)
                        greatest = newset2;
                }

            for (int newy = y + 1; newy < this.height; newy++)
            {
                var newset2 = this.ExpandSet(newset, left, top, x, newy);

                if (newset2 != null && newset2.Count > greatest.Count)
                    greatest = newset2;
            }

            return greatest;
        }
    }
}
