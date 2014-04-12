namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Master
    {
        public object Solve(int nrows, int ncols, int nmines)
        {
            int nempty = nrows * ncols - nmines;

            for (int k = nrows; k >= (nrows == 1 ? 1 : 2); k--)
                for (int j = ncols; j >= (ncols == 1 ? 1 : 2); j--)
                {
                    int size = k * j;

                    if (size > nempty)
                        continue;

                    int rest = nempty % size;

                    if (rest == 0)
                        return Generate(nrows, ncols, k, j, 0);

                    if (rest == 1)
                        continue;

                    if (rest % 2 == 0 || (k > 2 && j > 2))
                        return Generate(nrows, ncols, k, j, rest);
                }

            return "Impossible";
        }

        private object Generate(int nrows, int ncols, int height, int width, int rest)
        {
            Board board = new Board(nrows, ncols);
            board.SetEmpty(height, width);
            board.SetClick(0, 0);

            int y = 0;
            int x = width;

            while (rest >= 2 && y + 1 < height && x < ncols)
            {
                board.SetEmptyCell(y, x);
                board.SetEmptyCell(y + 1, x);
                rest -= 2;
                x++;

                if (x >= ncols)
                {
                    y += 2;
                    x = width;

                    if (y >= height)
                        break;
                }
            }

            if (rest > 0 && y == 0)
            {
                y = 2;
                x = width;
            }

            while (rest > 0 && y < height && x < ncols)
            {
                board.SetEmptyCell(y, x++);
                rest--;

                if (x >= ncols)
                {
                    y++;
                    x = width;
                }
            }

            return board.ToLines();
        }
    }
}
