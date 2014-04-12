namespace MagicTrick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Magician
    {
        public object Resolve(int nrow1, Grid grid1, int nrow2, Grid grid2)
        {
            var row1 = grid1.GetRow(nrow1);
            var row2 = grid2.GetRow(nrow2);

            var result = row1.Intersect(row2).ToList();

            if (result.Count == 0)
                return "Volunteer cheated!";

            if (result.Count > 1)
                return "Bad magician!";

            return result[0];
        }
    }
}
