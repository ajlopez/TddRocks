namespace MagicTrick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Grid
    {
        private IList<IList<int>> rows = new List<IList<int>>();

        public Grid(IList<string> rowsdata)
        {
            foreach (var rowdata in rowsdata)
                rows.Add(GetNumbers(rowdata));
        }

        public IList<int> GetRow(int nrow)
        {
            return rows[nrow - 1];
        }

        private static IList<int> GetNumbers(string data)
        {
            var numbers = data.Trim().Split(' ');

            return numbers.Select(number => int.Parse(number)).ToList();
        }
    }
}
