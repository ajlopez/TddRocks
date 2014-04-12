namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Board
    {
        private int nrows;
        private int ncols;
        private char[,] cells;

        public Board(int nrows, int ncols)
        {
            this.nrows = nrows;
            this.ncols = ncols;
            this.cells = new char[nrows, ncols];
        }

        public IList<string> ToLines()
        {
            IList<string> lines = new List<string>();

            for (var nrow = 0; nrow < this.nrows; nrow++)
                lines.Add(this.ToLine(nrow));

            return lines;
        }

        public void SetEmpty(int nr, int nc)
        {
            for (int k = 0; k < nr; k++)
                for (int j = 0; j < nc; j++)
                    this.cells[k, j] = '.';
        }

        public void SetEmptyCell(int nr, int nc)
        {
            this.cells[nr, nc] = '.';
        }

        public void SetClick(int nr, int nc)
        {
            this.cells[nr, nc] = 'c';
        }

        private string ToLine(int nrow)
        {
            string result = string.Empty;

            for (int j = 0; j < this.ncols; j++) 
            {
                char ch = this.cells[nrow, j];

                if (ch == 0)
                    result += '*';
                else
                    result += ch;
            }

            return result;
        }
    }
}
