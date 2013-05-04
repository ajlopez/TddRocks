namespace Diamonds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Calculator
    {
        public double Calculate(int x, int y)
        {
            if ((x + y) % 2 != 0)
                return 0;

            throw new NotImplementedException();
        }
    }
}
