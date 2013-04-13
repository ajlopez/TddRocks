namespace TicTacToeTomek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Board
    {
        private char[,] cells = new char[4,4];

        public Board()
            : this(string.Empty)
        {
        }

        public Board(string cells)
        {
            int len = cells.Length;

            for (int k = 0; k < 4; k++)
                for (int j = 0; j < 4; j++)
                {
                    int pos = k + j * 4;

                    if (pos >= len)
                        this.cells[j, k] = '.';
                    else
                        this.cells[j, k] = cells[pos];
                }
        }

        public Status Evaluate()
        {
            for (int j = 0; j < 4; j++)
            {
                int nx = 0;
                int no = 0;
                int nt = 0;

                for (int k = 0; k < 4; k++)
                    if (this.cells[j, k] == 'X')
                        nx++;
                    else if (this.cells[j, k] == 'O')
                        no++;
                    else if (this.cells[j, k] == 'T')
                        nt++;

                if (nx == 4 || (nx == 3 && nt == 1))
                    return Status.XWon;

                if (no == 4 || (no == 3 && nt == 1))
                    return Status.OWon;
            }

            return Status.Draw;
        }
    }
}
