namespace Diamonds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Calculator
    {
        public double Calculate(int n, int x, int y)
        {
            if ((x + y) % 2 != 0)
                return 0;

            int l = (Math.Abs(x) + Math.Abs(y)) / 2;

            int enough = this.NeededDiamonds(l + 1);

            if (enough <= n)
                return 1;

            int needed = this.NeededDiamonds(l);

            if (needed > n)
                return 0;

            throw new NotImplementedException();
        }

        public int NeededDiamonds(int l)
        {
            int total = 1;
            int delta = 5;
            for (int k = 0; k < l; k++)
            {
                total += delta;
                delta += 4;
            }

            return total;
        }
    }
}
