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
        private int[] rowmoves;
        private int[] columnmoves;

        public Pattern(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.cells = new int[height, width];
            this.rowmoves = new int[height];
            this.columnmoves = new int[width];
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }

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

        public bool IsValidRowMove(int nrow, int move)
        {
            if (this.rowmoves[nrow] > 0)
                return false;

            for (int k = 0; k < this.width; k++)
                if (this.cells[nrow, k] > move)
                    return false;

            return true;
        }

        public bool IsValidColumnMove(int ncol, int move)
        {
            if (columnmoves[ncol] > 0)
                return false;

            for (int k = 0; k < this.height; k++)
                if (this.cells[k, ncol] > move)
                    return false;

            return true;
        }

        public void MoveRow(int nrow, int value)
        {
            this.rowmoves[nrow] = value;
        }

        public void MoveColumn(int ncol, int value)
        {
            this.columnmoves[ncol] = value;
        }

        public Cell GetMaxUnsolved()
        {
            Cell result = null;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (this.IsSolved(y, x))
                        continue;
                    int value = this.cells[y, x];
                    if (result == null || result.Value < value)
                        result = new Cell() { Row = y, Column = x, Value = value };
                }

            return result;
        }

        public bool IsSolved(int nrow, int ncol)
        {
            int value = this.cells[nrow, ncol];
            return this.rowmoves[nrow] == value || this.columnmoves[ncol] == value;
        }

        public bool HasSolution()
        {
            Cell cell = this.GetMaxUnsolved();

            if (cell == null)
                return true;

            if (this.IsValidRowMove(cell.Row, cell.Value))
            {
                this.MoveRow(cell.Row, cell.Value);
                if (this.HasSolution())
                    return true;
                this.MoveRow(cell.Row, 0);
            }

            if (this.IsValidColumnMove(cell.Column, cell.Value))
            {
                this.MoveColumn(cell.Column, cell.Value);
                if (this.HasSolution())
                    return true;
                this.MoveColumn(cell.Column, 0);
            }

            return false;
        }
    }
}
