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

                    return Generate(nrows, ncols, k, j, rest);
                }

            return "Impossible";
        }

        private object Generate(int nrows, int ncols, int height, int width, int size)
        {
            return null;
        }
    }
}
