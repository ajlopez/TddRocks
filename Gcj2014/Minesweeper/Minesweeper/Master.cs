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
            if (nrows * ncols - nmines <= 4)
                return "Impossible";

            for (int k = nrows; k >= 2; k--)
            {
                int j = nmines / k;

                if (j < 1)
                    continue;

                int size = k * j;

                if ((nmines % size) % 2 == 0)
                    return Generate(nrows, ncols, k, j, size);
            }

            return "Impossible";
        }

        private object Generate(int nrows, int ncols, int height, int width, int size)
        {
            return null;
        }
    }
}
